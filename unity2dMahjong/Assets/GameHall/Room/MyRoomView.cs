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
    public class MyRoomView : MonoBehaviour
    {
        public UserNode[] userNodes;//玩家的基础信息类数组
        public Text roomInfoText;//显示房间基础信息的Text组件
        public Button btnReady;//准备按钮
        public Text btnText;//按钮名字
        public bool isClick = false;//是否点击了
        private void Awake()
        {
            new RoomControl(this);
        }
        // Use this for initialization
        void Start()
        {
            U3DSocket.shareSocket().StartRead();
            this.transform.Find("Panel/top/top_sets/btn_exit").GetComponent<Button>().onClick.AddListener(()=> {
                //先发送退出房间指令
                this.gameObject.SetActive(false);
                SceneManager.LoadScene("MyGameHall");
                //Destroy(this.gameObject);
            });
            this.btnReady.onClick.AddListener(() =>
            {
                if (!isClick)
                {
                    isClick = true;
                    ByteBuffer buffer = ByteBuffer.CreateBufferAndType(Protocol.准备或取消指令);
                    int isReady =0;
                    if (this.btnText.text.Equals("准备"))
                    {
                        isReady = 1;
                    }
                    else if (this.btnText.text.Equals("取消"))
                    {
                        isReady = -1;
                    }
                    buffer.writeInt(isReady);
                    buffer.Send();
                    
                }
                else
                {
                    print("************************************");
                    print("你点击的太快了，服务器还没有反应过来！");
                    print("************************************");

                }
            });
            
        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}

