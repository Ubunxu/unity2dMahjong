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
        private string roomId = "";//房间号码
        private int index = 0;
        // Use this for initialization
        void Start()
        {
            BtnCloseListener();
            BtnNumListener();
        }
        /// <summary>
        /// 关闭窗口按钮事件
        /// </summary>
        private void BtnCloseListener()
        {
            this.transform.Find("Panel/bgImage/btn_close").GetComponent<Button>().onClick.AddListener(() => {
                //Destroy(this.transform.gameObject);//该句话是将此游戏对象销毁，那之后要用的话，则会报出空引用的错误，所以一般简单的关闭不要用它
                this.transform.gameObject.SetActive(false);
                ClearAllInput();
            });
        }
        /// <summary>
        /// 数字按钮的监听事件。
        /// </summary>
        private void BtnNumListener()
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
        /// <summary>
        /// 根据点击的按钮，对输入框进行赋值
        /// </summary>
        /// <param name="num"></param>
        private void InputRoomId(string num)
        {
            if (num.Equals("reset"))
            {
                ClearAllInput();
            }
            else if (num.Equals("del"))
            {
                if (index > 0)
                {
                    inputTexts[--index].text = "";
                    roomId = roomId.Substring(0, index);
                }
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
                    ClearAllInput();

                }
            }
        }
        /// <summary>
        /// 清空输入框中的内容
        /// </summary>
        private void ClearAllInput()
        {
            foreach (Text text in inputTexts)
            {
                text.text = "";
                roomId = "";
            }
            index = 0;
        }
        /// <summary>
        /// 向服务器发送加入房间的信息
        /// </summary>
        /// <param name="_roomId"></param>
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

