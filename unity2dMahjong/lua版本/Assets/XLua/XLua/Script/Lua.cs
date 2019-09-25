using UnityEngine;
using System.Collections;
using XLua;//声明使用xlua

public class Lua : MonoBehaviour {
   public delegate void myDelegate();
    myDelegate awake;
    myDelegate start ;
    myDelegate onEnable;
    myDelegate update;
    LuaEnv evn = new LuaEnv();
    private LuaTable scriptEven;
    void Awake()
    {
       
        evn.DoString("require('Text')");
        evn.Global.Get("Text", out scriptEven);
        scriptEven.Get("Awake",out awake);
        scriptEven.Get("Start", out start);
        scriptEven.Get("OnEnable", out onEnable);
        scriptEven.Get("Update", out update);
        awake();
    }
    void OnEnable()
    {
        onEnable();
    }
    // Use this for initialization
    void Start () {

        start();
    }
    void Update()
    {
        update();
    }
}
