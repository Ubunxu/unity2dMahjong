using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

/// <summary>
/// 整个项目中，只能有一个LUA虚拟机
/// </summary>
public class LuaENV
{
    private static LuaEnv evn = null;
    public static LuaEnv GetLuaEnv
    {
        get{
            if (evn == null) evn = new LuaEnv();
            return evn;
        }
    }
}
