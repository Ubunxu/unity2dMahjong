using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XLua;
using System;

[LuaCallCSharp]
public class LuaRunningBehaviour : MonoBehaviour
{


    public string tableName;

    public TextAsset luaScript;


    //虚拟机，就是一台电脑,专门用来解析当前的Lua文件
    internal static LuaEnv luaEnv =  LuaENV.GetLuaEnv; //all lua behaviour shared one luaenv only!    

    private Action luaStart;//对应Lua文件中的Start方法
    private Action luaUpdate;//对应Lua文件中的Update方法
    private Action luaOnDestroy;//对应Lua文件中的Destroy方法

    //LuaTable: 对应Lua中的table
    private LuaTable scriptEnv;//提共给Lua虚拟机的脚本程序,最终将我们写的Lua程序加载到该对象中来
    
    void Awake()
    {
        //创建一个Lua中的表,用来保存Lua中的表
        scriptEnv = luaEnv.NewTable();
        
        //建立元表，创建面向对象
        LuaTable meta = luaEnv.NewTable();
        meta.Set("__index", luaEnv.Global);
        scriptEnv.SetMetaTable(meta);
        meta.Dispose();
        
        //把lua脚本开始加载到lua虚拟机中去
        luaEnv.DoString(luaScript.text);//,tableName, scriptEnv);

        //把当前表名放到表中去
        luaEnv.Global.Get(tableName, out scriptEnv);

        //把当前对象存入到Lua虚拟机角本中去，我们可以在lua脚本中通过self直接调用C#对象中的方法和属性
        scriptEnv.Set("self", this);

        Action awakeAction = scriptEnv.Get<Action>("Awake");
        scriptEnv.Get("Start", out luaStart);
        scriptEnv.Get("Update", out luaUpdate);

        if (awakeAction!=null)
        {
            awakeAction();
        }
    }
    // Use this for initialization
    void Start()
    {
        if (luaStart != null)
        {
            luaStart();
        }
    }
    // Update is called once per frame
    void Update()
    {
     
        if (luaUpdate != null)
        {
            
            luaUpdate();
        }
        //if (Time.time - LuaBehaviour.lastGCTime > GCInterval)
        //{
        //    luaEnv.Tick();
        //    LuaBehaviour.lastGCTime = Time.time;
        //}
       // Rigidbody r = this.gameObject.AddComponent<Rigidbody>();
        //r.AddForce(this.transform.forward * 1000)
    }

    void OnDestroy()
    {
        if (luaOnDestroy != null)
        {
            luaOnDestroy();
        }
        luaOnDestroy = null;
        luaUpdate = null;
        luaStart = null;
        scriptEnv.Dispose();
    }
}