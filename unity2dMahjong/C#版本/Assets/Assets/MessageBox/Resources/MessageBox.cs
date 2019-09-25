using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
/*
  项目名称 ：广东麻将
  开发日间 ：2018.4.17
  版本     : v.10
  作者     ：Test
*/
public class MessageBox : MonoBehaviour
{
    private string title = "";
    private string content = "";
    public Text titleText = null;
    public Text contentText = null;
    public Button closeButton = null;
    public GameObject parent = null;
    public Transform JiangLiGrid = null;
    private UnityAction callBack = null;
    private static MessageBox instance = null;
    private static Canvas canvas = null;

    private static GameObject self = null;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        closeButton.onClick.AddListener(delegate()
        {
            showHide(false);
            if (callBack != null)
            {
                callBack();
                callBack = null;
            }
            Destroy(this.gameObject);
        });
        showHide(true);
        if(GameObject.Find("EventSystem")==null)
        {
            transform.Find("ES").gameObject.SetActive(true);
        }
    }

    public static void show(string _content = "",string _title="提示",UnityAction _callBack=null)
    {
        MessageBox.Create();
        instance.title = _title;
        instance.content = _content;
        instance.titleText.text = instance.title;
        instance.contentText.text = instance.content;
        instance.showHide(true);
        instance.callBack = _callBack;
    }
    private void showHide(bool sh)
    {
        if (canvas == null) canvas = GetComponent<Canvas>();
        if (!parent.activeSelf) parent.SetActive(true);
        canvas.enabled = sh;
        if (!sh)
        {
            this.title = "";
            this.content = "";
        }
    }
    public static void setTitle(string _title)
    {
        instance.title = _title;
    }
    public static void setContent(string _content)
    {
        instance.content = _content;
    }
    private static void Create()
    {
        if (instance == null)
        {
            GameObject o = Resources.Load<GameObject>("MessageBox");
            GameObject ot = Instantiate<GameObject>(o);
            ot.name = "MessageBox";
            //Log.warn("创建了一次");
        }
        else
        {
            //Log.warn("不用创建了");
        }
    }
}