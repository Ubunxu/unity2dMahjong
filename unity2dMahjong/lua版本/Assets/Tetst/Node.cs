using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
	四川麻将
	时间:2017.6.12
	作者:风一样的程序员
	版本:2.6
*/
namespace SC_MahJong
{
	public class Node : MonoBehaviour
    {
        public string Text1 = null;
        public string Text2 = null;
        public string Image = null;


		public void setText1(string value)
        {
            this.Text1 = value;
            this.transform.Find("Text1").GetComponent<Text>().text = value;
        }
        public void setText2(string value)
        {
            this.Text2 = value;
            this.transform.Find("Text2").GetComponent<Text>().text = value;
        }
        public void setImage(string img)
        {
            this.Image = img;
            this.GetComponent<DownImage>().LoadImage(img);
        }

        public void setValue(string t1,string t2,string img)
        {
            setText1(t1);
            setText2(t2);
            setImage(img);
        }

	}
}
