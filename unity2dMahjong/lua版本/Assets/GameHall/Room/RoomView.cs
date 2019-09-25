using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using util.net;
using util.core;
using UnityEngine.SceneManagement;
using System.Linq;

/*
四川麻将
时间：2017.6.12
作者：风一样的程序员
版本：2.6
*/
namespace SC_MahJong
{
    public class RoomView : MonoBehaviour
    {
        private Dictionary<string, User> userDic = new Dictionary<string, User>();
        public RoomView()
        {
            EventDispatch.addEventListener(this, "do");
            U3DSocket.shareSocket().StartRead();
        }

        // Use this for initialization
        void Start()
        {

        }

      
        /// <summary>
        /// 把房间所有信息发送给某个玩家。
        /// </summary>
        /// <param name="buffer"></param>
        public void do7000(ByteBuffer buffer)
        {
            int roomId = buffer.readInt();
            string roomName = buffer.readString();
            int roomJs = buffer.readInt();
            int playerMethod = buffer.readInt();
            string dqHsz = buffer.readString();
            int fanshu = buffer.readInt();

            int playerLength = buffer.readInt();
            while (playerLength > 0)
            {
                string username = buffer.readString();
                string userCname = buffer.readString();
                int postion = buffer.readInt();
                string userImage = buffer.readString();
                int userReady = buffer.readInt();
                User user = new User(username, userCname, postion, userImage, userReady);
                userDic.Add(username, user);
                playerLength--;
            }
            print("================房间中所有玩家的信息");
            print(roomId + " " + roomName + "  " + roomJs + "  " + playerMethod + " " + dqHsz + " " + fanshu + " ");
            ShowUserInfo();
        }

        private void ShowUserInfo()
        {
            User[] users = userDic.Values.ToArray<User>();
            int myPosation = userDic[Player.GetPlayer().Username].Postion;
            foreach (User user in users)
            {
                int postion = user.Postion - myPosation;
                switch (postion)
                {
                    case 0:
                        //自己
                        this.transform.Find("Panel/bottom/Image/txt_bottomname").GetComponent<Text>().text = user.Username;
                        this.transform.Find("Panel/bottom/headimg_bottom").GetComponent<DownImage>().setImage(user.UserImage);
                        break;

                    case 1:
                        this.transform.Find("Panel/left/txt_leftname").GetComponent<Text>().text = user.Username;
                        this.transform.Find("Panel/left/headimg_left").GetComponent<DownImage>().setImage(user.UserImage);
                        break;
                    case -3:
                        this.transform.Find("Panel/left/txt_leftname").GetComponent<Text>().text = user.Username;
                        this.transform.Find("Panel/left/headimg_left").GetComponent<DownImage>().setImage(user.UserImage);
                        break;

                    case -1:
                        this.transform.Find("Panel/right/txt_rightname").GetComponent<Text>().text = user.Username;
                        this.transform.Find("Panel/right/headimg_right").GetComponent<DownImage>().setImage(user.UserImage);
                        break;
                    case 3:
                        this.transform.Find("Panel/right/txt_rightname").GetComponent<Text>().text = user.Username;
                        this.transform.Find("Panel/right/headimg_right").GetComponent<DownImage>().setImage(user.UserImage);
                        break;

                    case -2:
                        this.transform.Find("Panel/top/txt_topname").GetComponent<Text>().text = user.Username;
                        this.transform.Find("Panel/top/headimg_top").GetComponent<DownImage>().setImage(user.UserImage);
                        break;
                    case 2:
                        this.transform.Find("Panel/top/txt_topname").GetComponent<Text>().text = user.Username;
                        this.transform.Find("Panel/top/headimg_top").GetComponent<DownImage>().setImage(user.UserImage);
                        break;

                    default:
                        break;

                }
            }

        }
        /// <summary>
        /// 玩家加入房间,某个玩家的消息发送给房间的其他所有人(自己加入房间也会收到自己的，所以要排除自己的)
        /// </summary>
        /// <param name="buffer"></param>
        public void do7001(ByteBuffer buffer)
        {
            string username = buffer.readString();
            string userCname = buffer.readString();
            int posation = buffer.readInt();
            string userImage = buffer.readString();
            User user = new User(username, userCname, posation, userImage, 0);
            if (!userDic.ContainsKey(username))
            {
                userDic.Add(username, user); 
            }


        }
        /// <summary>
        /// 玩家退出房间
        /// </summary>
        /// <param name="buffer"></param>
        public void do7999(ByteBuffer buffer)
        {
            int postion = buffer.readInt();
            string username = buffer.readString();



        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

