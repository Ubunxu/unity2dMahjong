using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using util.net;
using util.core;
using UnityEngine.SceneManagement;

/*
四川麻将
时间：2017.6.12
作者：风一样的程序员
版本：2.6
*/
namespace SC_MahJong
{
    public class MyRoomView : MonoBehaviour
    {
        public UserNode[] userNodes;//玩家的基础信息类数组
        public Text roomInfoText;//显示房间基础信息的Text组件
        public Button btnReady;//准备按钮
        public Text btnText;//按钮名字
        public bool isClick = false;//是否点击了
        private void Awake()
        {
            new RoomControl(this);
        }
        // Use this for initialization
        void Start()
        {
            //U3DSocket.shareSocket().StartRead();
            //房间退出按钮
            this.transform.Find("Panel/top/top_sets/btn_exit").GetComponent<Button>().onClick.AddListener(()=> {
                //先发送退出房间指令
                this.gameObject.SetActive(false);
                SceneManager.LoadScene("MyGameHall");
                //Destroy(this.gameObject);
            });
            //准备按钮
            this.btnReady.onClick.AddListener(() =>
            {
                if (!isClick)
                {
                    isClick = true;
                    ByteBuffer buffer = ByteBuffer.CreateBufferAndType(Protocol.准备或取消指令);
                    int isReady =0;
                    if (this.btnText.text.Equals("准备"))
                    {
                        isReady = 1;
                    }
                    else if (this.btnText.text.Equals("取消"))
                    {
                        isReady = -1;
                    }
                    buffer.writeInt(isReady);
                    buffer.Send();
                    
                }
                else
                {
                    print("************************************");
                    print("你点击的太快了，服务器还没有反应过来！");
                    print("************************************");

                }
            });
            int[] cards = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 21, 22, 23, 24 };
            this.ShowMahJong(TransCard(cards));
            this.ShowOtherMahjong();
        }

        public string[] TransCard(int[] cards)
        {
            string[] trans = new string[cards.Length];
            int i = -1;
            foreach (int card in cards)
            {
                string type = (int)card / 10 + "";
                string value = (int)card % 10 + "";
                string cardName = "p4b" + type + "_" + value;
                trans[++i] = cardName;
            }
            return trans;

        }

        public void ShowMahJong(string[] cards)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>("MJCard");
            Dictionary<string, Sprite> mjSpriteDic = new Dictionary<string, Sprite>();
            foreach (Sprite mj in sprites)
            {
                mjSpriteDic.Add(mj.name, mj);
            }
            for(int i = 0; i < cards.Length; ++i)
            {
                GameObject mjObj = Instantiate(Resources.Load("Mahjong0")) as GameObject;
                mjObj.transform.SetParent(GameObject.Find("Panel/bottom/img_mj").transform, false);

                (mjObj.transform as RectTransform).anchoredPosition = new Vector2(61.5f + 123 * i, -92.5f);
                mjObj.transform.GetComponent<Image>().sprite = mjSpriteDic[cards[i]];
            }
        }

        public void ShowOtherMahjong()
        {
            for(int i = 0; i < 13; ++i)
            {
                GameObject mjObj1 = Instantiate(Resources.Load("Mahjong" + 1)) as GameObject;
                mjObj1.transform.SetParent(GameObject.Find("Panel/left/img_mj").transform, false);
                (mjObj1.transform as RectTransform).anchoredPosition = new Vector2(0,180f-27f*i);

                GameObject mjObj2 = Instantiate(Resources.Load("Mahjong" + 2)) as GameObject;
                mjObj2.transform.SetParent(GameObject.Find("Panel/top/img_mj").transform, false);
                (mjObj2.transform as RectTransform).anchoredPosition = new Vector2(400f -67.1f * i, 0);

                GameObject mjObj3 = Instantiate(Resources.Load("Mahjong" + 3)) as GameObject;
                mjObj3.transform.SetParent(GameObject.Find("Panel/right/img_mj").transform, false);
                (mjObj3.transform as RectTransform).anchoredPosition = new Vector2(0, 180f-27f*i);
            }

        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}

