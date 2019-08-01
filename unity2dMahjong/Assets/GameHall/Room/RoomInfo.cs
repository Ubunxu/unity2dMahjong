using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
四川麻将
时间：2017.6.12
作者：风一样的程序员
版本：2.6
*/
namespace SC_MahJong
{
    public class RoomInfo
    {
        private int roomId;
        private int gameCount = 0;
        private int gamePlayMethod = 0;
        private string dqHsz = null;
        private int gameFanshu = 0;
        private int myPostion = 0;

        private List<User> userList = new List<User>();

        public int GameCount
        {
            get
            {
                return gameCount;
            }

            set
            {
                gameCount = value;
            }
        }

        public int GamePlayMethod
        {
            get
            {
                return gamePlayMethod;
            }

            set
            {
                gamePlayMethod = value;
            }
        }

        public string DqHsz
        {
            get
            {
                return dqHsz;
            }

            set
            {
                dqHsz = value;
            }
        }

        public int GameFanshu
        {
            get
            {
                return gameFanshu;
            }

            set
            {
                gameFanshu = value;
            }
        }

        public int RoomId
        {
            get
            {
                return roomId;
            }

            set
            {
                roomId = value;
            }
        }

        public int MyPostion
        {
            get
            {
                return myPostion;
            }

            set
            {
                myPostion = value;
            }
        }

        public List<User> UserList
        {
            get
            {
                return userList;
            }

            set
            {
                userList = value;
            }
        }

        public void AddUser(User user)
        {
            userList.Add(user);

            if (user.Username.Equals(Player.GetPlayer().Username))
            {
                this.myPostion = user.Postion;
            }
        }
        
        public void Remove(string _username)
        {
            foreach (User user in userList)
            {
                if (user.Username.Equals(_username))
                {
                    this.userList.Remove(user);
                    break;
                }
            }
        }
        public User[] GetUsers()
        {
            return this.userList.ToArray();
        }


    }
}

