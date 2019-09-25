using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace util.core
{
    public class EventDispatch
    {

        public delegate void windowCall(int methodName, params object[] objs);

        static windowCall wCall = null;
        static Dictionary<int, Node> dict = new Dictionary<int, Node>();
        public static void addEventListener(string className, string priex = "do")
        {
            //1：根据字符串类名 获得该类的类型
            Type type = Type.GetType(className);//线程.A, 线程.B
                                                //2：创建对象
            object parent = Activator.CreateInstance(type);//new A();
                                                           //获得所有方法,返回一个方法数组
                                                           //MethodInfo m = type.GetMethod("do1001");
            MethodInfo[] ms = type.GetMethods();
            //取出所有指定开头的方法
            for (int i = 0; i < ms.Length; i++)
            {
                MethodInfo mth = ms[i];
                if (mth.Name.StartsWith(priex))
                {
                    Node node = new Node();
                    node.parent = parent;
                    node.method = mth;
                    node.action = null;
                    int sName = int.Parse(mth.Name.Substring(priex.Length));
                    dict.Add(sName, node);
                    //Console.WriteLine(mth.Name);
                }
            }
        }
        public static void addEventListener(object p, string priex = "do")
        {
            //1：根据字符串类名 获得该类的类型
            Type type = p.GetType();// Type.GetType(className);//线程.A, 线程.B
                                    //2：创建对象
            object parent = p;// Activator.CreateInstance(type);//new A();
                              //获得所有方法,返回一个方法数组
                              //MethodInfo m = type.GetMethod("do1001");
            MethodInfo[] ms = type.GetMethods();
            //取出所有指定开头的方法
            for (int i = 0; i < ms.Length; i++)
            {
                MethodInfo mth = ms[i];
                if (mth.Name.StartsWith(priex))
                {
                    Node node = new Node();
                    node.parent = parent;
                    node.method = mth;
                    node.action = null;
                    int sName = int.Parse(mth.Name.Substring(priex.Length));
                    if (!dict.ContainsKey(sName))
                    {
                        dict.Add(sName, node);
                        //Console.WriteLine(mth.Name);
                    }

                }
            }
        }
        public static void dispatchEvent(int methodName, params object[] objs)
        {
            if (dict.ContainsKey(methodName))
            {
                Node node = dict[methodName];
                node.Run(objs);
            }
            else
            {
                UnityEngine.Debug.Log("错误的协议类型： " + methodName);
            }
        }
        public static bool ContanisKey(int key)
        {
            return dict.ContainsKey(key);
        }
        public static void Remove(int key)
        {
            dict.Remove(key);
        }
        public static void Remove(object p, string priex)
        {
            //1：根据字符串类名 获得该类的类型
            Type type = p.GetType();// Type.GetType(className);//线程.A, 线程.B
                                    //2：创建对象
            object parent = p;// Activator.CreateInstance(type);//new A();
                              //获得所有方法,返回一个方法数组
                              //MethodInfo m = type.GetMethod("do1001");
            MethodInfo[] ms = type.GetMethods();
            //取出所有指定开头的方法
            for (int i = 0; i < ms.Length; i++)
            {
                MethodInfo mth = ms[i];
                if (mth.Name.StartsWith(priex))
                {
                    int sName = int.Parse(mth.Name.Substring(priex.Length));
                    if (dict.ContainsKey(sName))
                    {
                        dict.Remove(sName);
                    }
                }
            }
        }
        public static void Remove(string className, string priex)
        {
            //1：根据字符串类名 获得该类的类型
            Type type = Type.GetType(className);//线程.A, 线程.B
                                                //2：创建对象
            object parent = Activator.CreateInstance(type);//new A();
                                                           //获得所有方法,返回一个方法数组
                                                           //MethodInfo m = type.GetMethod("do1001");
            MethodInfo[] ms = type.GetMethods();
            //取出所有指定开头的方法
            for (int i = 0; i < ms.Length; i++)
            {
                MethodInfo mth = ms[i];
                if (mth.Name.StartsWith(priex))
                {
                    int sName = int.Parse(mth.Name.Substring(priex.Length));
                    if (dict.ContainsKey(sName))
                    {
                        dict.Remove(sName);
                    }
                }
            }
        }

        //==================== Lua ===================================//
        public static void addLuaEventListener(string luaTableName, string priex = "do")
        {
            XLua.LuaTable luaTable = LuaENV.GetLuaEnv.Global.Get<XLua.LuaTable>(luaTableName);
            addLuaEventListener(luaTable, priex);
        }
        public static void addLuaEventListener(XLua.LuaTable scriptEnv, string priex = "do")
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
                            Node node = new Node();
                            node.parent = null;
                            node.method = null;
                            //unityAction3 unityFunction;
                            //scriptEnv.Get(it.Current.ToString(), out node.action);
                            node.action = scriptEnv.Get<XLua.LuaFunction>(it.Current.ToString());
                            if (!dict.ContainsKey(name))
                            {
                                dict.Add(name, node);
                                Logger.wanr(it.Current, "Lua 事件注册成功");
                            }
                            else
                            {
                                Logger.wanr("Lua方法注册 失败: " + name);
                            }
                        }
                    }
                }
            }
            catch (Exception e) { Logger.wanr("Lua事件注册时出错"); Logger.wanr(e.Message); }
        }
    }
    class Node
    {
        public object parent;
        public MethodInfo method;
        public XLua.LuaFunction action;

        //public void initNode(object parent, MethodInfo method,unityAction3 act)
        //{
        //    this.parent = parent;
        //    this.method = method;
        //    this.action = act;
        //}
        public void Run(params object[] objs)
        {
            if (action != null)
            {
                action.Call(objs);
            }
            else
            {
                this.method.Invoke(this.parent, objs);
            }
        }
    }
}