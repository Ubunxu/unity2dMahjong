using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using util.net;
using util.core;
/*
四川麻将
时间：2017.6.12
作者：昂
版本：2.9

*/
namespace SC_MahJong
{
    public class createRoom : MonoBehaviour {

	    // Use this for initialization
	    void Start () {


            this.transform.Find("bg/but_Close").GetComponent<Button>().onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
            });


            //获得 创建房间 这个按钮，然后给他点击事件，改路径就型了

            this.transform.Find("bg/Center/Line6/Button").GetComponent<Button>().onClick.AddListener(() =>
            {
                CreateRoom();
            });
		
	    }

        public void CreateRoom()
        {
           // string s = "";
            bool ss = false;
            string s = "";
            bool isAdd = true;
            ByteBuffer bu = ByteBuffer.CreateBufferAndType(8000);
            //获取我这个脚本挂在的对象的所有的《Toggle》子节点
            Toggle[] toggle=this.transform.GetComponentsInChildren<Toggle>();

            //遍历数组
            for (int i=0;i<toggle.Length;i++)
            {
                //判断是否选中
                if(toggle[i].isOn)
                {
                    //因为是按照顺序来的，所以第0个也就是创建房间的第一个选择（4局），如果被选中，就把4写进去
                    if (i == 0) bu.writeInt(4);
                    //同理，第一个就是（8局），被选中就写8进去
                    if (i == 1) bu.writeInt(8);
                    if (i == 2) bu.writeInt(16);
                    if (i == 3) bu.writeInt(24);
                    if (i == 4) bu.writeInt(1);
                    if (i == 5) bu.writeInt(2);
                    if (i == 6) bu.writeInt(3);
                    //第7和8比较特殊，是可以多选单选或者不选的，当7被选中就把“定缺”保存起来，同时告诉把ss（告诉后面，我勾了7）变成true
                    if (i == 7)
                    {
                        s += "dq";
                        ss = true;
                    }
                    if (i == 8)
                    {
                        //如果选择了8，这里就会进来，在“定缺”的基础上在加上“#hsz”
                        if (ss) s += "#hsz";
                        else s+="hsz";
                        //如果没有选择7，就会进这里，只保存“换三证”就好
                    }
                    //如果大于等于8，并且没有上传的时候，就把之前保存的s上传，就是“dq”或者“hsz”或者“dq#hsz”
                    if (i >= 8 && isAdd)
                    {
                        bu.writeString(s);
                        isAdd = false;
                    }
                    if (i == 9) bu.writeInt(6);
                    if (i == 10) bu.writeInt(8);
                    if (i == 11) bu.writeInt(0);
                }
            }
            //这一段是打印给你自己看的，在不确定上传的是正确的时候，先自己打印看看，把send注释掉

            //while (bu.Available > 0)
            //{
            //    Debug.Log(bu.readInt());
            //    Debug.Log(bu.readInt());
            //    Debug.Log(bu.readInt());
            //    Debug.Log(bu.readString());
            //    Debug.Log(bu.readInt());
            //}
            //发送
             bu.Send();
        }
	    // Update is called once per frame
	    void Update () {
		
	    }
    }
}