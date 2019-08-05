using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using util.net;
using util.core;
using UnityEngine.SceneManagement;
using System.Threading;

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
        public Button btnReady_2;//新的准备按钮
        public Text btnText;//按钮名字
        public bool isClick = false;//是否点击了
        public Dictionary<string, Sprite> mjSpriteDic = new Dictionary<string, Sprite>();

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

            //新的准备按钮，不用考虑取消的情况，
            this.btnReady_2.onClick.AddListener(() =>
            {
                if (!isClick)
                {
                    isClick = true;
                    ByteBuffer buffer = ByteBuffer.CreateBufferAndType(Protocol.准备或取消指令);
                    buffer.writeInt(1);
                    buffer.Send();
                }
                else
                {
                    print("************************************");
                    print("你点击的太快了，服务器还没有反应过来！");
                    print("************************************");

                }
            });


            int[] cards = { 11, 12, 16, 17, 18, 19, 21, 22, 13, 14, 15, 23, 24 };
            this.ShowMahJong(TransCard(SortCard(cards)));
        }
        /// <summary>
        /// 对牌进行排序之冒泡排序
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public int[] SortCard(int[] cards) 
        {
            if (cards.Length == 0)
            {
                return cards;
            }
            for(int i = 0; i < cards.Length; ++i)
            {
                int flag = 0;
                for(int j = 0; j < cards.Length - 1 - i; ++j)
                {
                    if (cards[j + 1] < cards[j])
                    {
                        int temp = cards[j];
                        cards[j] = cards[j + 1];
                        cards[j + 1] = temp;
                        flag = 1;
                    }
                }
                if (flag == 0) break;
            }
            return cards;
        }
        /// <summary>
        /// 将int数组转换为牌的图片名字
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
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


        /// <summary>
        /// 显示麻将
        /// </summary>
        /// <param name="cards"></param>
        public void ShowMahJong(string[] cards)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>("MJCard");
            //Dictionary<string, Sprite> mjSpriteDic = new Dictionary<string, Sprite>();
            foreach (Sprite mj in sprites)
            {
                mjSpriteDic.Add(mj.name, mj);
            }
            StartCoroutine(Show(mjSpriteDic, cards));

        }
        /// <summary>
        /// 协程调用的方法
        /// </summary>
        /// <param name="mjSpriteDic"></param>
        /// <param name="cards"></param>
        /// <returns></returns>
        private IEnumerator Show(Dictionary<string, Sprite> mjSpriteDic, string[] cards)
        {
            for(int i = 0; i < cards.Length; ++i)
            {
                yield return new WaitForSeconds(0.3f);
                MyClone(mjSpriteDic, cards, i);
                OthersClone(i);
            }            
        }
        /// <summary>
        /// 克隆麻将对象
        /// </summary>
        /// <param name="mjSpriteDic"></param>
        /// <param name="cards"></param>
        /// <param name="i"></param>
        private void MyClone(Dictionary<string, Sprite> mjSpriteDic, string[] cards,int i)
        {
            GameObject mjObj = Instantiate(Resources.Load("Mahjong0")) as GameObject;
            mjObj.transform.SetParent(GameObject.Find("Panel/bottom/img_mj").transform, false);

            (mjObj.transform as RectTransform).anchoredPosition = new Vector2(61.5f + 123 * i, -92.5f);
            mjObj.transform.GetComponent<Image>().sprite = mjSpriteDic[cards[i]];

            Button cardBtn = mjObj.transform.GetComponent<Button>();
            cardBtn.onClick.AddListener(() =>
            {
                print("点击监听事件");
                mjObj.transform.GetComponent<CardClickListener>().Move();
            });










            //=========================测试打牌的排版=======================

            GameObject mjObj2 = Instantiate(Resources.Load("DMahjong0")) as GameObject;
            mjObj2.transform.SetParent(GameObject.Find("Panel/bottom/sendMahjong").transform, false);

            //(mjObj2.transform as RectTransform).anchoredPosition = new Vector2(-247.5f + 55 * i, 42f);
            mjObj2.transform.GetComponent<Image>().sprite = mjSpriteDic[cards[i].Replace('b', 's')];

            GameObject mjObj3 = Instantiate(Resources.Load("DMahjong1")) as GameObject;
            mjObj3.transform.SetParent(GameObject.Find("Panel/left/sendMahjong").transform, false);

            //(mjObj2.transform as RectTransform).anchoredPosition = new Vector2(-247.5f + 55 * i, 42f);
            mjObj3.transform.GetComponent<Image>().sprite = mjSpriteDic[cards[i].Replace('b', 's').Replace("p4", "p3")];

             GameObject mjObj4 = Instantiate(Resources.Load("DMahjong2")) as GameObject;
            mjObj4.transform.SetParent(GameObject.Find("Panel/top/sendMahjong").transform, false);

            //(mjObj2.transform as RectTransform).anchoredPosition = new Vector2(-247.5f + 55 * i, 42f);
            mjObj4.transform.GetComponent<Image>().sprite = mjSpriteDic[cards[i].Replace('b', 's').Replace("p4", "p2")];

             GameObject mjObj5 = Instantiate(Resources.Load("DMahjong3")) as GameObject;
            mjObj5.transform.SetParent(GameObject.Find("Panel/right/sendMahjong").transform, false);

            //(mjObj2.transform as RectTransform).anchoredPosition = new Vector2(-247.5f + 55 * i, 42f);
            mjObj5.transform.GetComponent<Image>().sprite = mjSpriteDic[cards[i].Replace('b', 's').Replace("p4", "p1")];

            
        }

        private void OthersClone(int i)
        {
            GameObject mjObj1 = Instantiate(Resources.Load("Mahjong" + 1)) as GameObject;
            mjObj1.transform.SetParent(GameObject.Find("Panel/left/img_mj").transform, false);
            (mjObj1.transform as RectTransform).anchoredPosition = new Vector2(0, 180f - 27f * i);

            GameObject mjObj2 = Instantiate(Resources.Load("Mahjong" + 2)) as GameObject;
            mjObj2.transform.SetParent(GameObject.Find("Panel/top/img_mj").transform, false);
            (mjObj2.transform as RectTransform).anchoredPosition = new Vector2(400f - 67.1f * i, 0);

            GameObject mjObj3 = Instantiate(Resources.Load("Mahjong" + 3)) as GameObject;
            mjObj3.transform.SetParent(GameObject.Find("Panel/right/img_mj").transform, false);
            (mjObj3.transform as RectTransform).anchoredPosition = new Vector2(0, 180f - 27f * i);
        }


       
        // Update is called once per frame
        void Update()
        {

        }
    }
}

