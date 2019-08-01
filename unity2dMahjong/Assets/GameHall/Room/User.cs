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
    public class User
    {

        private int userId;
        private string username;
        private string userCname;
        private int postion;
        private string userImage;
        private int userReady;

        public User(string username, string userCname, int postion, string userImage, int userReady)
        {
            this.Username = username;
            this.UserCname = userCname;
            this.Postion = postion;
            this.UserImage = userImage;
            this.UserReady = userReady;
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string UserCname
        {
            get
            {
                return userCname;
            }

            set
            {
                userCname = value;
            }
        }

        public int Postion
        {
            get
            {
                return postion;
            }

            set
            {
                postion = value;
            }
        }

        public string UserImage
        {
            get
            {
                return userImage;
            }

            set
            {
                userImage = value;
            }
        }

        public int UserReady
        {
            get
            {
                return userReady;
            }

            set
            {
                userReady = value;
            }
        }
    }
}

