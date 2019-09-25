using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
/*
四川麻将
时间：2017.6.12
作者：风一样的程序员
版本：2.6
*/
namespace util
{
    public class MyLuaEventDispatcher
    {
        private static Dictionary<int, LuaFunction> funcs = new Dictionary<int, LuaFunction>();
        
        /// <summary>
        /// 方法重载（添加协议方法）
        /// </summary>
        /// <param name="luaTableName"></param>
        /// <param name="prefix"></param>
        public static void AddEventListener(string luaTableName,string prefix = "do")
        {
            LuaTable luatable = LuaENV.GetLuaEnv.Global.Get<LuaTable>(luaTableName);
            AddEventListener(luatable, prefix);
        }
        /// <summary>
        /// 添加协议方法
        /// </summary>
        /// <param name="scriptEnv"></param>
        /// <param name="prefix"></param>
        public static void AddEventListener(LuaTable scriptEnv,string prefix = "do")
        {
            
        }
    }
}

