using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
namespace util
{
    public class LuaEventDispatcher
    {
        [XLua.CSharpCallLua] public delegate void unityAction3(object message);
        private static Dictionary<int, unityAction3> funcs = new Dictionary<int, unityAction3>();

        public static void addEventLinstener(string luaTableName, string priex = "do")
        {
            XLua.LuaTable luaTable = LuaENV.GetLuaEnv.Global.Get<XLua.LuaTable>(luaTableName);
            addEventLinstener(luaTable, priex);
        }
        //添加方法
        public static void addEventLinstener(XLua.LuaTable scriptEnv, string priex = "do")
        {
            IEnumerator it = scriptEnv.GetKeys().GetEnumerator();
            try
            {
                while (it.MoveNext())
                {
                    object f = scriptEnv.Get<object>(it.Current.ToString());
                    if (f != null && f.GetType() == typeof(XLua.LuaFunction))
                    {
                        if (it.Current.ToString().StartsWith(priex))
                        {
                            int name = int.Parse(it.Current.ToString().Substring(priex.Length));
                            unityAction3 unityFunction;
                            scriptEnv.Get(it.Current.ToString(), out unityFunction);
                            if(!isLinsteners(name))
                            {
                                funcs.Add(name, unityFunction);
                            }
                            Logger.wanr(it.Current, "Lua 事件注册成功");
                        }
                    }
                }
            }
            catch (Exception e) { Logger.wanr("Lua事件注册时出错");Logger.wanr(e.Message); }
        }
        //执行方法
        public static void DispatchEvent(int type, object pars)
        {
            if (isLinsteners(type))
            {
                unityAction3 unity3 = LuaEventDispatcher.funcs[type];
                unity3(pars);
            }
        }
        //检测是否存在
        public static bool isLinsteners(int type)
        {
            if (!LuaEventDispatcher.funcs.ContainsKey(type)) return false;
            return true;
        }
        //移除所有
        public void removeAllLinsteners()
        {
            LuaEventDispatcher.funcs.Clear();
            //formRun = null;
        }
        //移除一个
        public static void removeLinstener(int type)
        {
            if (LuaEventDispatcher.funcs.ContainsKey(type))
            {
                LuaEventDispatcher.funcs.Remove(type);
            }
        }
        public static int LinstenerCount
        {
            get { return LuaEventDispatcher.funcs.Count; }
        }
    }
    class NodeLua
    {
        int key;
        object obj;
        XLua.LuaFunction method;        
        public NodeLua(int _key, object _obj, XLua.LuaFunction _method)
        {
            key = _key;
            obj = _obj;
            method = _method;
        }
        public void Run(params object[] pars)
        {
            //method.Invoke(obj, pars);
        }
    }
}