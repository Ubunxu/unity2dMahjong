using System.Collections;
using System.Collections.Generic;
using System.Threading;
//using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using util.net;
/*
四川麻将
时间：2017.6.12
作者：昂
版本：2.9

*/
namespace SC_MahJong
{
    public class addRoom : MonoBehaviour {
        private Text[] nubKK;
        private int index = 0;
	    // Use this for initialization
	    void Start ()
        {
            this.transform.Find("bg/but_Close").GetComponent<Button>().onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
            });
            nubKK = this.transform.Find("Center/Line2").GetComponentsInChildren<Text>();
            btnOnlisk();
        }
        public void btnOnlisk()
        {
           Button[] btn= this.transform.Find("Center").GetComponentsInChildren<Button>();

            foreach(Button b in btn)
            {
                b.onClick.AddListener(() =>
                {
                    numberDisplay(b.name);
                });
            }
        }
        public void numberDisplay(string str)
        {
            if(str.Equals("delet"))
            {          
                nubKK[index-1].text = "";
                if (index == 0) return;
                index--;
                return;
            }
            if (index <= 5)
            {
                nubKK[index].text = str;
                print("密码：   " + str);
                
                index++;
            }
            if (index == 6)
            {
                string roomId = "";
                foreach (Text t in nubKK)
                {
                    roomId += t.text;
                    t.text = "";
                }
                sendRoomId(roomId);
                //print(int.Parse(roomId));
            }
        }
        public void sendRoomId(string roomId)
        {
            ByteBuffer bu = ByteBuffer.CreateBufferAndType(8001);
            bu.writeInt(int.Parse(roomId));
            bu.Send();
            index = 0;
        }

	    // Update is called once per frame
	    void Update () {
		
	    }
    }
}