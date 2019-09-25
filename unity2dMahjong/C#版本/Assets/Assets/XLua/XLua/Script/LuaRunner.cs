using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using XLua;
using util;
/*
四川麻将
时间：2017.6.12
作者：风一样的程序员
版本：2.6
*/
[LuaCallCSharp]
public class LuaRunner : MonoBehaviour
{
    LuaEnv luaenv = LuaENV.GetLuaEnv;
    public TextAsset textFile = null;
    public string luaFileName = null;
    private LuaTable table;
    private Action luaAwake = null;
    private Action luaStart = null;
    private Action luaUpdate = null;
    private Action luaOnDestroy = null;
    private MyAction2 luaOnCollisionEnter = null;
    private MyAction2 luaOnTriggerEnter = null;
    private bool luaFileIsNull = true;//判断一开始是否传了文件名或者文件(默认是null，没有传)

    private Vector3 oldPos;
    private void Awake()
    {
        InitLua();
    }
    /// <summary>
    /// 初始化相关的lua配置，并且进行了时候传了文件或文件名的判断
    /// </summary>
    private void InitLua()
    {
        if(textFile!=null || luaFileName != null)
        {
            luaFileIsNull = false;
            string luaStr = null;
            string luaName = null;
            if (textFile == null)
            {
                if (luaFileName == null)
                {
                    print("没有任何lua文件");
                    return;
                }
                else
                {
                    luaStr = Resources.Load<TextAsset>("lua/" + luaFileName).text;
                    luaName = luaFileName.Substring(0, luaFileName.IndexOf('.'));
                }
            }
            else
            {
                luaStr = textFile.text;
                luaName = textFile.name.Substring(0, textFile.name.IndexOf('.'));
            }

            luaenv.DoString(luaStr);//将lua文本转换成C#可以认识的编程语言
            luaenv.Global.Get(luaName, out table);//将一个表读出来，相当于C#中的一个类

            //使用lua自带的luafunction方式来得到方法
            //LuaFunction awake = table.Get<LuaFunction>("Awake");
            //if (awake != null)
            //{
            //    awake.Call();   
            //}

            //直接从方法里面提取一个方法的委托然后调用
            luaAwake = table.Get<Action>("Awake");

            if (luaAwake != null)
            {
                luaAwake();
            }
            //将this和transform存入table中，这样在lua脚本中就可以使用
            table.Set("self", this);
            table.Set("transform", transform);

            table.Get("Start", out luaStart);
            table.Get("Update", out luaUpdate);
            table.Get("OnDestroy", out luaOnDestroy);
            table.Get("OnCollisionEnter", out luaOnCollisionEnter);
            table.Get("OnTriggerEnter", out luaOnTriggerEnter);
        }
    }

    // Use this for initialization
    void Start()
    {
        oldPos = this.transform.position;
        if (luaFileIsNull)
        {
            InitLua();
        }
        if (luaStart != null)
        {
            luaStart();
        }
        //this.transform.GetComponent(typeof(Rigidbody));   --经常要在lua文件使用的
    }

    /// <summary>
    /// 用于测试的
    /// </summary>
    public void TestSet()
    {
        print("我是CSharp中的公共方法");        
    }

   /// <summary>
   /// 这个是用于访问lua文件之间的方法调用使用的
   /// </summary>
   /// <param name="methodName">lua1调用lua2中的方法名</param>
   /// <param name="objs">上面方法的动态参数</param>
   /// <returns></returns>
    public object[] CallLuaFunction(string methodName,params object[] objs)
    {
        LuaFunction func = table.Get<LuaFunction>(methodName);
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

    private void LateUpdate()
    {
        oldPos = this.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //碰撞
        if (luaOnCollisionEnter != null)        
        {
            //luaOnCollisionEnter(collision);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //触发
        if(luaOnTriggerEnter != null)
        {
            luaOnTriggerEnter(other);
        }

    }
    private void OnDestroy()
    {
        if (luaOnDestroy != null)
        {
            luaOnDestroy();
        }
        luaStart = null;
        luaUpdate = null;
        luaOnDestroy = null;
        table.Dispose();//释放表
    }

    /// <summary>
    /// 射线检测
    /// </summary>
    public void TestRay()
    {
        Vector3 newPos = this.transform.position;
        print("oldPos:" + oldPos + "   newPos:" + newPos);
        Debug.DrawRay(this.transform.position, this.transform.forward*5, Color.red);
        print(Vector3.Distance(oldPos, newPos));
        RaycastHit hit;
        if (Physics.Raycast(oldPos, (oldPos - newPos).normalized, out hit,3f))
        {
            GameObject obj = hit.collider.gameObject;
            print(obj.name);
            if (obj.name.Equals("qiang"))
            {
                DestroyObject(obj);
            }
        }
    }
}

