using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
四川麻将
时间：2017.6.12
作者：昂
版本：2.9

*/
namespace SC_MahJong
{
    public class deskNode : MonoBehaviour
    {
        private string uName = null;
        public string cName = null;
        private string image = null;
        private int _isRead = 0;

        public string UName
        {
            get
            {
                return uName;
            }

            set
            {
                uName = value;
            }
        }

        public void setUName(string _uName)
        {
            Destroy(transform.GetChild(0).gameObject);
            cName = _uName;
            this.transform.Find("Text").GetComponent<Text>().text = _uName;
        }
        public void setIsRead(int read)
        {
            

            _isRead = read;
            bool s = true;
            if (read > 0) s = false;
            else if(read<0) s = true;
            this.transform.Find("readImg").GetComponent<Image>().gameObject.SetActive(s);
        }
        public void setImage(string img)
        {
            //string filePath = "file://" + Application.dataPath + @"/_Image/grid.png";
           //print("--------------------------"+Application.dataPath);
            //C:\Users\入木三分啊。\Documents\New Unity Project\Assets\GameRoom\img
            if (img == "") img = "file://" + Application.dataPath + @"/GameRoom/img/aa.png";
            image = img;
            this.transform.GetComponent<DownImage>().loadImage(img);
        }
    }
}