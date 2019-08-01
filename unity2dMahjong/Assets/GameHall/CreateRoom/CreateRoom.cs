using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using util.net;
using util.core;

/*
四川麻将
时间：2017.6.12
作者：风一样的程序员
版本：2.6
*/
namespace SC_MahJong
{
    public class CreateRoom : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            EventDispatch.addEventListener(this, "do");
            this.transform.Find("Panel/bgImage/contentPanel/line6/btn_createRoom").GetComponent<Button>().onClick.AddListener(() =>
            {
                GetCreateRoomData();
            });
            this.transform.Find("Panel/bgImage/closeButt1").GetComponent<Button>().onClick.AddListener(()=> {
                this.transform.gameObject.SetActive(false);               

            });
        }

        private void BtnCloseListener()
        {

        }

        //得到创建的房间的信息
        private void GetCreateRoomData()
        {
            int jushu=4, xuanze=1,fanshu=6;
            string wanfa = "";
            Transform transform = this.transform.Find("Panel/bgImage/contentPanel");
            Toggle[] toggle1 = transform.Find("line1/groupToggle").GetComponentsInChildren<Toggle>();
            Toggle[] toggle2 = transform.Find("line2/groupToggle2").GetComponentsInChildren<Toggle>();
            Toggle[] toggle3 = transform.Find("line3/groupToggle3").GetComponentsInChildren<Toggle>();
            Toggle[] toggle4 = transform.Find("line4/groupToggle4").GetComponentsInChildren<Toggle>();

            //巧妙的利用将每个toggle设置为对应的发送值（比如说：4 为4局等。。。）可以是代码简化，利用foreach
            for(int i = 0; i < toggle1.Length; ++i)
            {
                if (toggle1[i].isOn)
                {
                    switch (i)
                    {
                        case 0:
                            jushu = 4;
                            break;
                        case 1:
                            jushu = 8;
                            break;
                        case 2:
                            jushu = 16;
                            break;
                        case 3:
                            jushu = 24;
                            break;
                        default:
                            break;
                    }
                }
            }

            for(int i = 0; i < toggle2.Length; ++i)
            {
                if (toggle2[i].isOn)
                {
                    switch (i)
                    {
                        case 0:
                            xuanze = 1;
                            break;
                        case 1:
                            xuanze = 2;
                            break;
                        case 2:
                            xuanze = 3;
                            break;
                        default:
                            break;
                    }
                }
            }

            for(int i = 0; i < toggle3.Length; ++i)
            {
                if (toggle3[0].isOn) wanfa = "dq";
                if (toggle3[1].isOn) wanfa = "hsz";
                if (toggle3[0].isOn && toggle3[1].isOn) wanfa = "dq#hsz";
            }

            for(int i = 0; i < toggle4.Length; ++i)
            {
                if (toggle4[i].isOn)
                {
                    switch (i)
                    {
                        case 0:
                            fanshu = 6;
                            break;
                        case 1:
                            fanshu = 8;
                            break;
                        case 3:
                            fanshu = 0;
                            break;
                        default:
                            break;
                    }
                }
            }

            print("jushu:" + jushu + " xuanze: " + xuanze + "wanfa: " + wanfa + "fanshu:" + fanshu);

            ByteBuffer buffer = ByteBuffer.CreateBufferAndType(Protocol.创建房间指令);
            buffer.writeInt(jushu);
            buffer.writeInt(xuanze);
            buffer.writeString(wanfa);
            buffer.writeInt(fanshu);
            buffer.Send();
        }

       
        public void do8000(ByteBuffer buffer)
        {
            int roomId = buffer.readInt();
            print("roomId : " + roomId);
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}

