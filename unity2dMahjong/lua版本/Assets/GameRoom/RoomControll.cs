using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using util.net;
using util.core;
using UnityEngine.UI;
/*
四川麻将
时间：2017.6.12
作者：昂
版本：2.9

*/
namespace SC_MahJong
{
    public class RoomControll
    {

        private roomInfo RoomInfo;
        private deskNode[] desk;

        private GameObject[] parents;

        private static  RoomControll shar = null;
        private bool ss = false;
        private Text roomText;
        private Button Read;

        Dictionary<int, deskNode> dic = new Dictionary<int, deskNode>();//用来保存座位号，和对应的桌子


        private RoomControll()
        {
            RoomInfo = new roomInfo();
            EventDispatch.addEventListener(this, "do");
            Debug.Log("newlControll");
           
        }

        public static RoomControll sharRoomControll()
        {
            if (shar == null) shar = new RoomControll();
            return shar;
        }
        public void setDesk(deskNode[] dn)
        {
            desk = dn;
        }
        public void setText(Text t)
        {
            roomText = t;
        }
        public void setButten(Button t)
        {
            Read = t;
            sendMeState();
        }
        public void setParent(GameObject[] t)
        {
            parents = t;
            
        }

        public void sendMeState()
        {
            Read.transform.Find("isRead").GetComponent<Button>().onClick.AddListener(() =>
            {
                if (!ss)
                {
                    
                    ByteBuffer bu = ByteBuffer.CreateBufferAndType(8006);

                    Text tt = Read.transform.Find("isRead").GetComponent<Text>();
                    if (tt.text.Equals("准备"))
                    {
                        bu.writeInt(1);
                        dic[Player.SharPlayer().Pos].setIsRead(1);
                        tt.text = "取消准备";
                    }
                    else
                    {
                        bu.writeInt(-1);
                        dic[Player.SharPlayer().Pos].setIsRead(-1);
                        tt.text = "准备";
                    }
                    bu.Send();
                    ss = true;
                }
            });
        }

        public void do7000(ByteBuffer buffer)
        {
            int roomId = buffer.readInt();
            string roomName = buffer.readString();
            int JS = buffer.readInt();
            int play = buffer.readInt();//玩法
            string DqHsz = buffer.readString();
            int FS = buffer.readInt();//番数
            int userLength = buffer.readInt();

            RoomInfo.RoomId = roomId;
            RoomInfo.GameCount = JS;
            RoomInfo.GamePlayer = play;
            RoomInfo.DqHsz = DqHsz;
            RoomInfo.Fs1 = FS;

            while (userLength > 0)
            {
                string uName = buffer.readString();
                string cName = buffer.readString();
                int Pso = buffer.readInt();
                string uImage = buffer.readString();
                int read = buffer.readInt();

                if (uName.Equals(Player.SharPlayer().UName))
                {
                    Player.SharPlayer().Pos = Pso;
                    Debug.Log("我的坐标：" + Pso);
                }
                //new一个用户，把名字之类的信息保存起来
                User user = new User(uName, cName, uImage, read, Pso);
                

                RoomInfo.addUser(user);

                //userList.Add(user);
                userLength--;
            }
            //当7000执行完毕，也就是收到了所有房间内的人的消息之后，调用下面的方法（包括自己也保存起来了）
            DisplayUser();
            ListRoomInfo();

        }
        public void DisplayUser()
        {
            //单例自己，把自己的座位号并保存起来
            Player play = Player.SharPlayer();
            int myPos = play.Pos;
            //遍历四张桌子
            for (int i = 0; i < desk.Length; i++)
            {
                //保存到字典中，座位号对应桌子号，每次保存完了，我的座位号再加1，把座位号对应起来，就是
                dic.Add(myPos, desk[i]);
                myPos++;
                if (myPos >= 4) myPos = 0;
            }

            for (int j = 0; j < RoomInfo.getUser().Length; j++)
            {
                dic[RoomInfo.getUser()[j].Pos].setUName(RoomInfo.getUser()[j].CName);
                dic[RoomInfo.getUser()[j].Pos].setImage(RoomInfo.getUser()[j].Image);
                dic[RoomInfo.getUser()[j].Pos].setIsRead(RoomInfo.getUser()[j].Ready);
                // dic[RoomInfo.getUser()[j].Pos].UName = RoomInfo.getUser()[j].UName;

            }
        }
        public void ListRoomInfo()
        {
            string str = "";

            str = RoomInfo.GameCount + "局 ";
            if (RoomInfo.GamePlayer == 1) str += "血战到底 ";
            else if (RoomInfo.GamePlayer == 2) str += "血流成河 ";
            else str += "两房牌 ";

            str += RoomInfo.DqHsz + " ";

            str += RoomInfo.Fs1 + "番 ";

            str += "房间号: " + RoomInfo.RoomId  ;

            roomText.text = str;
            Debug.Log("当前房间Id:"+ RoomInfo.RoomId);
        }
        public void do7001(ByteBuffer buffer)
        {
            string uName = buffer.readString();
            string cName = buffer.readString();
            int Pso = buffer.readInt();
            string uImage = buffer.readString();
            int read = buffer.readInt();


            //因为之前我们已经保存过自己了，所以如果事自己就直接返回
            if (uName.Equals(Player.SharPlayer().UName)) return;

            User user = new User(uName, cName, uImage, read, Pso);

            RoomInfo.addUser(user);

            //userList.Add(user);

            dic[Pso].setImage(uImage);
            dic[Pso].setUName(cName);
            dic[Pso].setIsRead(read);
        }
        public void do7999(ByteBuffer buffer)
        {
            string uName = buffer.readString();
            int Pso = buffer.readInt();
            Debug.Log("离开人姓名：" + uName + "     座位号：" + Pso);

            dic[Pso].setImage("");
            dic[Pso].setUName("");
            dic[Pso].setIsRead(0);

            for (int n = 0; n < parents.Length; n++)
            {
                if (parents[n].transform == null)
                {
                    return;
                }
                for (int i = 0; i < parents[n].transform.childCount; i++)
                {
                    GameObject.Destroy(parents[n].transform.GetChild(i).gameObject);
                }
                parents[n].transform.DetachChildren();

            }

            for (int i = 0; i < RoomInfo.getUser().Length; i++)
            {
                if (RoomInfo.getUser()[i].UName == uName)
                {
                    RoomInfo.removeUser(i);
                    break;
                }
            }
            Read.gameObject.SetActive(true);
        }
        public void do8006(ByteBuffer buffer)
        {
            string uName = buffer.readString();
            int isRead = buffer.readInt();
            int Pos = buffer.readInt();

            if(uName==Player.SharPlayer().UName) ss = false;
            
            dic[Pos].setIsRead(isRead);

        }
        public void do8110(ByteBuffer buffer)
        {
            Debug.Log("游戏开始");

            Read.gameObject.SetActive(false);

        }

    }
}