using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using util.net;
using util.core;
using UnityEngine.SceneManagement;



/*
四川麻将
时间：2017.6.12
作者：风一样的程序员
版本：2.6
*/
namespace SC_MahJong
{
    public class Login : MonoBehaviour
    {
        private bool isConnection = false;
        // Use this for initialization
        void Start()
        {
            U3DSocket socket = U3DSocket.shareSocket();
            socket.ConnectTo(IP.ip, IP.port, () =>
            {
                print("连接成功");
                isConnection = true;
                EventDispatch.addEventListener(this, "do");
            }, (str) =>
            {
                print("连接失败：" + str);

            }, 10);


            this.transform.Find("Panel/Image/Button").GetComponent<Button>().onClick.AddListener(() =>
            {
                if (isConnection)
                {
                    ByteBuffer buffer = ByteBuffer.CreateBufferAndType(1001);
                    buffer.writeString("xjy");
                    buffer.writeString("123456");
                    buffer.Send();
                }
                
            });
        }
        

        public void do1001(ByteBuffer buffer)
        {
            print("我执行了");

            string username = buffer.readString();
            //string userCname = buffer.readString();
            string userCname = "徐金耀";
            string password = buffer.readString();
            string imageUrl = buffer.readString();

            Player.GetPlayer().SetPlayerInfo(username, userCname, password, imageUrl);

            SceneManager.LoadScene("MyGameHall");
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}

