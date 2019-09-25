using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using UnityEngine.Events;
using SC_MahJong;
using UnityEngine.UI;

[LuaCallCSharp]
public class LuaRun : MonoBehaviour
{
    //获得虚拟机
    LuaEnv luaenv = LuaENV.GetLuaEnv;

    public TextAsset textFile = null;
    public string luaFileName = null;

    public string luaString = null;
    public string luaName = null;
    private LuaTable table;
    
    private System.Action luaStart = null;
    private System.Action luaUpdate = null;
    private System.Action luaOnDestroy = null;
    

    private bool luaFileIsNull = true;
    

    void Awake()
    {
        //this.transform.parent.Find("").GetComponent<Text>().text
        if (textFile != null || luaFileName != null)
        {
            initLua();
        }
    }
    void initLua()
    {
        luaFileIsNull = false;

        table = luaenv.NewTable();

        if (string.IsNullOrEmpty(luaString))
        {
            if (textFile == null)
            {
                if (luaFileName == null)
                {
                    Debug.Log("没有lua文件");
                    return;
                }
                else
                {
                    luaString = Resources.Load<TextAsset>("lua/" + luaFileName).text;//TestLua.lua
                    luaName = luaFileName.Substring(0, luaFileName.IndexOf('.'));
                }
            }
            else
            {
                luaString = textFile.text;
                luaName = textFile.name.Substring(0, textFile.name.IndexOf('.'));
            }
        }

        print("++++++++++++++++++++"+luaString);
        luaenv.DoString(luaString);//lua2.lua

        // Debug.Log("tableName: " + luaName);
        luaenv.Global.Get(luaName, out table);

        System.Action awake = table.Get<System.Action>("Awake");
        

        //将数据存于lua中的table
        table.Set("self", this);
        table.Set("transform", transform);
        table.Get("Start", out luaStart);
        table.Get("Update", out luaUpdate);
        table.Get("OnDestroy", out luaOnDestroy);
        
        if (awake != null)
        {
            awake();
        }
    }



    // Use this for initialization
    void Start()
    {
        if (!string.IsNullOrEmpty(luaString))
        {
            initLua();
        }
        else
        {
            if (luaFileIsNull)
            {
                if (textFile != null || luaFileName != null)
                {
                    initLua();
                }
            }
        }
        if (luaStart != null)
        {
            //print(4);
            luaStart();
        }

        //GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //this.transform.localScale = Vector3.one * 2;      
    }

    public object[] CallLuaFunction(string funName, params object[] objs)
    {
        LuaFunction func = table.Get<LuaFunction>(funName);
        return func.Call(objs);
    }


    // Update is called once per frame
    void Update()
    {
        if (luaUpdate != null)
        {
            luaUpdate();
        }
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
        table.Dispose();
    }
}
