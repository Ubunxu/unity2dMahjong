using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using XLua;

public class ClickAndDoScale : MonoBehaviour {
    //定义委托方法来来保存lua中的事件
    delegate void ClickEven();
    ClickEven onClick;
    LuaEnv even = new LuaEnv();
    //lua1脚本中定义为lua1的变量
    LuaTable lua1;
    void Awake()
    {

        even.DoString("require('Lua1')");
        //这里定义一个名为transform的全局变量，设置变量的值为transform
        even.Global.Set("transform", transform);
        //获取lua1脚本中的lua1把值返回给本脚本中的lua1
        even.Global.Get("Lua1", out lua1);
        //从本脚本中的lua1中获取DoScale方法，返回给onClick事件
        lua1.Get("DoScale", out onClick);
    }
	// Use this for initialization
	void Start () {
       
    }
    public void OnClick()
    {

        //运行OnClick方法
        onClick();
       // transform.localScale = new Vector3(2,2,2);

    }
	// Update is called once per frame
	void Update () {
        ////声明一个luaTable(table在c#中的表现形式)
        //LuaTable luaTable;
        ////获取全局Table对象返回到lua中
        // even.Global.Get("要获取的luaTable的名字",out luaTable);
        //luaTable.Get("Awake",awake);

    }
}
