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
    public class Player
    {
        private string username;
        private string password;
        private int money;
        private string userCname;
        private string userImage;
        private static Player player = null;

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

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public int Money
        {
            get
            {
                return money;
            }

            set
            {
                money = value;
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

        private Player() { }
        public static Player GetPlayer()
        {
            if (player == null) player = new Player();
            return player;
        }

        public void SetPlayerInfo(string _username,string _userCname,string _password,int _money,string _userImage)
        {
            userCname = _userCname;
            username = _username;
            password = _password;
            money = _money;
            userImage = _userImage;
        }
    }
}

