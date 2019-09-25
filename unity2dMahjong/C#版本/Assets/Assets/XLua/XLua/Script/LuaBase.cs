using UnityEngine;
using System.Collections;
using XLua;
using UnityEngine.UI;
//using static UnityEngine.UI.Button;

public class LuaBase : MonoBehaviour {
    LuaEnv eve = new LuaEnv();
    //lua脚本所在路径
    public string luaPath;
    //lua脚本里面this的名字
    public string luaName;
  //  public Button btn;
    //定义Awake Start Upadate OnEnable 等时间对应的委托
    delegate void Action();
    Action awake;
    Action start;
    Action update;
    Action onEnable;
    void Awake()
    {
        //这里判断下是否有这个路径
        if (luaPath != null)
        {
            //有Lua脚本就运行lua脚本
            string luaString = string.Format("require'{0}'", luaPath);//看下是否不要小括号
            eve.DoString(luaString);

         // Button a =  gameObject.GetComponent<Button>();
           // btn.onClick.AddListener(Awake);
          //  a.onClick =
          //  ButtonClickedEvent click = new ButtonClickedEvent();

        }
        else
        {
            Debug.LogError("请在运行前设置luaPath");
        }
        LuaTable luaScript;
        //通过LuaName来获取this对应的Table返回到luaScript中
        eve.Global.Get(luaName, out luaScript);
        luaScript.Get("Awake",out awake);
        luaScript.Get("Start",out start);
        luaScript.Get("OnEnable",out onEnable);
        luaScript.Get("Update", out update);
        luaScript.Set("transform",transform);
        awake();
    }
    // Use this for initialization
    void Start () {
        start();
	}
    void OnEnable()
    {
        onEnable();
    }
	// Update is called once per frame
	void Update () {
        update();
	}
}
