using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using util.net;
/*
四川麻将
时间：2017.6.12
作者：风一样的程序员
版本：2.6
*/
namespace SC_MahJong
{
    public class AddRoom : MonoBehaviour
    {
        private Text[] inputTexts;
        private Button[] btn_nums;
        private string roomId = "";
        private int index = 0;
        // Use this for initialization
        void Start()
        {
            this.transform.Find("Panel/bgImage/btn_close").GetComponent<Button>().onClick.AddListener(() => {
                this.transform.gameObject.SetActive(false);
            });
            BtnListener();
        }
        private void BtnListener()
        {
            inputTexts = this.transform.Find("Panel/bgImage/LineContent/line2").GetComponentsInChildren<Text>();
            btn_nums = this.transform.Find("Panel/bgImage/LineContent/line3").GetComponentsInChildren<Button>();
            foreach (Button btn in btn_nums)
            {
                btn.onClick.AddListener(() =>
                {
                    InputRoomId(btn.name);
                });
            }
        }
        private void InputRoomId(string num)
        {
            if (num.Equals("reset"))
            {
                foreach (Text text in inputTexts)
                {
                    text.text = "";
                }
                index = 0;
            }
            else if (num.Equals("del"))
            {
                if (index > 0)  inputTexts[--index].text = "";
            }
            else
            {
                inputTexts[index].text = num;
                roomId += num;
                index++;
                if (index >= 6)
                {
                    //将房间号发送给服务器
                    SendRoomId(roomId);
                    index = 0;
                }
            }
        }

        private void SendRoomId(string _roomId)
        {
            ByteBuffer buffer = ByteBuffer.CreateBufferAndType(Protocol.加入房间指令);
            buffer.writeInt(int.Parse(_roomId));
            buffer.Send();            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

