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
    public class RoomControl
    {
        private Dictionary<int, UserNode> userNodeDic = new Dictionary<int, UserNode>();//服务器的座位号与客户端的usernode相对应
        private RoomInfo roomInfo;
        private MyRoomView myRoom;
        private int[] cards = new int[13];

        public RoomControl(MyRoomView _myRoom)
        {
            myRoom = _myRoom;
            EventDispatch.addEventListener(this, "do");
            roomInfo = new RoomInfo();
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

            this.roomInfo.RoomId = roomId;
            this.roomInfo.GameCount = roomJs;
            this.roomInfo.GamePlayMethod = playerMethod;
            this.roomInfo.DqHsz = dqHsz;
            this.roomInfo.GameFanshu = fanshu;


            int userCount = buffer.readInt();
            while (userCount > 0)
            {
                string username = buffer.readString();
                string userCname = buffer.readString();
                int postion = buffer.readInt();
                string userImage = buffer.readString();
                int userReady = buffer.readInt();
                User user = new User(username, userCname, postion, userImage, userReady);
                this.roomInfo.AddUser(user);
                userCount--;
            }

            ShowUserInfo();
            ShowRoomInfo();

        }

        public void ShowUserInfo()
        {
            int myPostion = this.roomInfo.MyPostion;

            for (int j = 0; j < this.myRoom.userNodes.Length; ++j)
            {
                userNodeDic.Add(myPostion, this.myRoom.userNodes[j]);
                myPostion++;
                if (myPostion >= this.myRoom.userNodes.Length) myPostion = 0;
            }

            User[] users = this.roomInfo.GetUsers();
            for (int k = 0; k < users.Length; ++k)
            {
                User user = users[k];
                UserNode userNode = userNodeDic[user.Postion];
                userNode.SetUserCname(user.UserCname);
                userNode.SetUserImageUrl(user.UserImage);
                //设置玩家的状态(老版的)
                //userNode.SetReadyText(user);
                //设置玩家的状态(新版的)
                userNode.SetReadyImg(user.UserReady);

                userNode.Postion = user.Postion;
                userNode.Username = user.Username;
            }

        }


        public void ShowRoomInfo()
        {
            string infoText = "";
            infoText = this.roomInfo.GameCount + "局 ";

            if (this.roomInfo.GamePlayMethod == 1)
            {
                infoText += "血战到底 ";
            }
            else if (this.roomInfo.GamePlayMethod == 2)
            {
                infoText += "血流成河";
            }
            else
            {
                infoText += " 两房牌";
            }

            infoText += " " + this.roomInfo.DqHsz;

            infoText += " " + this.roomInfo.GameFanshu + "番";

            this.myRoom.roomInfoText.text = infoText;

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
            int userReady = buffer.readInt();

            if (username.Equals(Player.GetPlayer().Username))
            {
                return;
            }
            User user = new User(username, userCname, posation, userImage, userReady);
            this.roomInfo.AddUser(user);
            UserNode userNode = userNodeDic[posation];
            userNode.SetUserCname(userCname);
            userNode.SetUserImageUrl(userImage);
            //设置玩家的状态(老版的)
            //userNode.SetReadyText(user);
            //设置玩家的状态(老版的)
            userNode.SetReadyImg(user.UserReady);

        }
        /// <summary>
        /// 玩家退出房间
        /// </summary>
        /// <param name="buffer"></param>
        public void do7999(ByteBuffer buffer)
        {
            string username = buffer.readString();
            int postion = buffer.readInt();
            this.roomInfo.Remove(username);
            UserNode userNode = userNodeDic[postion];
            userNode.ClearUserInfo();
        }

        /// <summary>
        /// 玩家准备或者取消协议
        /// </summary>
        /// <param name="buffer"></param>
        public void do8006(ByteBuffer buffer)
        {
            string username = buffer.readString();
            int isReady = buffer.readInt();
            int position = buffer.readInt();

            UserNode userNode = userNodeDic[position];
            ////准备和取消设置（新版的）
            userNode.SetReadyImg(isReady);
            this.myRoom.isClick = false;

            //准备和取消设置（老版的）
          
            /*
            if (username.Equals(Player.GetPlayer().Username))
            {
                
                if (isReady == 1)
                {
                    this.myRoom.btnText.text = "取消";
                }
                else if (isReady == -1)
                {
                    this.myRoom.btnText.text = "准备";
                }
                this.myRoom.isClick = false;
            }
            else
            {
                if (isReady == 1)
                {
                    userNode.txtReady.text = "准备";
                }
                else if(isReady==-1)
                {
                    userNode.txtReady.text = "取消";
                }

            }
            */


        }

        /// <summary>
        /// 四个人准备好了，然后开始游戏
        /// </summary>
        /// <param name="buffer"></param>
        public void do8110(ByteBuffer buffer)
        {
            Debug.Log("游戏开始了");
        }



        /// <summary>
        /// 服务器发牌
        /// </summary>
        /// <param name="buffer"></param>
        public void do8112(ByteBuffer buffer)
        {
            Debug.Log("开始发牌");
            for(int i = 0; i < 13; ++i)
            {
                cards[i] = buffer.readInt();
            }
            this.myRoom.ShowMahJong(this.myRoom.TransCard(this.myRoom.SortCard(cards)));
        }
    }
}

