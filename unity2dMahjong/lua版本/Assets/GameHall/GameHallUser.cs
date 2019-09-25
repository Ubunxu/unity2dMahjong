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
作者：昂
版本：2.9

*/
namespace SC_MahJong
{
    public class GameHallUser : MonoBehaviour {
       
        // Use this for initialization
        void Start () {

            EventDispatch.addEventListener(this, "do");
            
            Player play = Player.SharPlayer();
           // Debug.Log(play.Image);
            this.transform.Find("Panel/img_Yezi_top/img_Yezi/text_Name").GetComponent<Text>().text = play.CName;

            this.transform.Find("Panel/img_Yezi_top/img_Yezi/img_Que/img_Gold/text_Gold").GetComponent<Text>().text = play.Money+"";
            this.transform.Find("Panel/img_Yezi_top/img_Yezi/img_Que/but_UserKK/img_yellow/img_TouXiang").gameObject.GetComponent<DownImage>().loadImage(play.Image);
            createRoom();
            addroom();  
        }
        public void createRoom()
        {
            this.transform.Find("Panel/img_left_RoomKK/But_addRoom").GetComponent<Button>().onClick.AddListener(() =>
            {
                this.transform.Find("addRoom").gameObject.SetActive(true);
            });
        }
        public void addroom()
        {
            this.transform.Find("Panel/img_left_RoomKK/But_FoundRoom").GetComponent<Button>().onClick.AddListener(() =>
            {
                this.transform.Find("CreateRoom").gameObject.SetActive(true);
            });
        }
        public void do8000(ByteBuffer buffer)
        {
            print("创建房间成功！房间Id为：" + buffer.readInt());
        }
        public void do7901(ByteBuffer buffer)
        {
            print("进入房间成功");
            U3DSocket.shareSocket().StopRead();
            SceneManager.LoadScene("gameRoom");
        }
        // Update is called once per frame
        void Update () {
		
	    }
    }
}