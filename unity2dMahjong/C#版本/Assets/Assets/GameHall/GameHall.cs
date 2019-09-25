using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public class GameHall : MonoBehaviour
    {
        [SerializeField]
        private Text txtUserName;
        [SerializeField]
        private Text txtMoney;
        [SerializeField]
        private RawImage headImage;
        // Use this for initialization
        void Start()
        {
            EventDispatch.addEventListener(this, "do");
            this.transform.Find("Panel/left/joinRoomButt").GetComponent<Button>().onClick.AddListener(() =>
            {
                //跳转到加入房间的页面。
                this.transform.Find("AddRoom").gameObject.SetActive(true);

            });

            this.transform.Find("Panel/left/createRoomButt").GetComponent<Button>().onClick.AddListener(() =>
            {
                this.transform.Find("CreateRoom").gameObject.SetActive(true);

            });

        }
      
        /// <summary>
        /// 加入房间成功之后服务器发送下来的消息；
        /// </summary>
        /// <param name="buffer"></param>
        public void do7901(ByteBuffer buffer)
        {
            print("加入成功");
            U3DSocket.shareSocket().StopRead();
            SceneManager.LoadScene("MyGameRoom");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

