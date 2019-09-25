using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using util;
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
    public class WeiXinLogin : MonoBehaviour {


        private bool isCon = false;
	    // Use this for initialization
        private string  downPath = "http://192.168.1.103/version.json";
	    void Start ()
        {

            LoadFactory.LoadAssetText(downPath, this, callBack, false);
            //this.transform.parent
            //this.transform
            U3DSocket socket = U3DSocket.shareSocket();
            socket.ConnectTo(IP.ip, IP.port, (str) =>
            {
                EventDispatch.addEventListener(this, "do");
                print("连接成功");
                isCon = true;
            }, (str) =>
            {
                print("连接失败");
                isCon = false;
            });

		
	    }

        public void callBack(object obj,byte[] bytes)
        {

        }
	    public void GameHall()
        {
            if(isCon)
            {
                ByteBuffer bu = ByteBuffer.CreateBufferAndType(1001);
                bu.writeString("xujinyao");
                bu.writeString("123456");
                bu.Send();
            }
        }
	    // Update is called once per frame
	    void Update () {
		
	    }
        public void do1001(ByteBuffer buffer)
        {
            print("登录成功！");

          
            Player play = Player.SharPlayer();
            play.UName = buffer.readString();
            play.CName = buffer.readString();
            play.Money = buffer.readInt();
            play.DuanWei1 = buffer.readString();
            play.Image = buffer.readString();
            play.MyText1 = buffer.readString();
            SceneManager.LoadScene("gameHall");


            print(play.Image);
        }
    }
}