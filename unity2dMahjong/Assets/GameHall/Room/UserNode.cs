using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
四川麻将
时间：2017.6.12
作者：风一样的程序员
版本：2.6
*/
namespace SC_MahJong
{
    public class UserNode : MonoBehaviour
    {
        private string username;
        private int postion;
        private string userCname;
        private string imageUrl;
        public Text txtReady;//准备或取消的名字

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

        public string ImageUrl
        {
            get
            {
                return imageUrl;
            }

            set
            {
                imageUrl = value;
            }
        }

        public void SetUserCname(string _userCname)
        {
            this.userCname = _userCname;
            this.transform.Find("text").GetComponent<Text>().text = _userCname;
        }
        public void SetUserImageUrl(string _imageUrl)
        {
            this.imageUrl = _imageUrl;
            if (_imageUrl.Equals("null"))
            {
                _imageUrl = "file://"+Application.dataPath + "/PublicPicture/mjRoom_39.png";//Application.dataPath相当于该unity项目（项目名/Asset）在本地的路径.
            }            
            this.transform.Find("image").GetComponent<DownImage>().LoadImage(_imageUrl);
        }


        public void SetReadyText(User user)
        {
            if (!user.Username.Equals(Player.GetPlayer().Username))
            {
                if (user.UserReady == 1)
                {
                    this.txtReady.text = "准备";
                }
                else if(user.UserReady==-1)
                {
                    this.txtReady.text = "取消";
                }
            }
        }
        public void ClearUserInfo()
        {
            this.SetUserCname("xxxx");
            this.SetUserImageUrl("null");
            this.txtReady.text = "取消";
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

