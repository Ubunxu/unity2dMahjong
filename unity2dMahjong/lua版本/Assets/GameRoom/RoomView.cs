using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using util.core;
using util.net;
/*
四川麻将
时间：2017.6.12
作者：昂
版本：2.9

*/
namespace SC_MahJong
{
    public class RoomView : MonoBehaviour {

        public deskNode[] desk;
        public GameObject[] parents;
        private int num;
        List<int> list = new List<int>();
        // Use this for initialization
        void Start ()
        {
            EventDispatch.addEventListener(this, "do");
            U3DSocket.shareSocket().StartRead();
            sendToControll();
        }
        public void sendToControll()
        {

            RoomControll roomControll = RoomControll.sharRoomControll();
            roomControll.setDesk(desk);
            roomControll.setText(this.transform.Find("Panel/Image (5)/roomInfoText").GetComponent<Text>());
            roomControll.setButten(this.transform.Find("Panel/my_User/Button").GetComponent<Button>());
            roomControll.setParent(parents);


        }
        public IEnumerator sendMj()//IEnumerator这个是协程的意思，用协程启动函数必须要这样写
        {
            Dictionary<string, Sprite> dic = new Dictionary<string, Sprite>();//建一个字典，用来保存所有的麻将的图片，键是名字，值是图片本身

            Sprite[] mjs = Resources.LoadAll<Sprite>("MJImage");//保存的所有的图片
            for (int i = 0; i < mjs.Length; i++)
            {
                //Debug.Log(mjs[i].name + "------" + mjs[i]);
                dic.Add(mjs[i].name, mjs[i]);//for循环添加进字典
            }
            while (list.Count > 0)//接接收到的服务器发的13张牌的数组
            {
                num = list[0];//取出list第0个，加载
                GameObject mj = Resources.Load("MaJiang") as GameObject;//我方牌的预制体

                //其他人的牌的预制体，因为要和我们一样一张一张出来，所以同时也加载
                GameObject lmj = Resources.Load("left_mjPrefabs") as GameObject;

                GameObject tmj = Resources.Load("top_mjPrefabs") as GameObject;

                GameObject rmj = Resources.Load("right_mjPrefabs") as GameObject;

                //给预制体设置父对象
                // Instantiate(mj).transform.SetParent(this.transform.Find("Panel/myMJ_Parent"));

                GameObject obj = Instantiate(mj, this.transform.Find("Panel/myMJ_Parent")) as GameObject;

                Instantiate(lmj).transform.SetParent(this.transform.Find("Panel/leftMJ_Paent"));

                Instantiate(tmj).transform.SetParent(this.transform.Find("Panel/topMJ_Parent"));

                Instantiate(rmj).transform.SetParent(this.transform.Find("Panel/rightMJ_Parent"));

                //mj.gameObject.transform.localRotation = new Vector3(0, 0,0);

                //截取服务器发下来的第0张牌的名字的十位数，代表类型（如1是万）
                int type = num / 10;
                int value = num % 10;//截取个位数，代表是几（如1是类型的第一张）

                string card = "p4b" + type + "_" + value;//拼接成p4b1_1这种类型，才可以找到,p4b代表是我方的牌

                Sprite mjimage = dic[card];//用键找到值，字典的键值对

                obj.transform.GetComponent<Image>().sprite = mjimage;//mj是我方麻将的预制体，找到他身上的image组件，把服务器发下来的图片复制给他

                list.RemoveAt(0);//删除保存的牌的第0个

                yield return new WaitForSeconds(0.3f);//这个代码是写在协程里的，是暂停0.3秒的意思




                while (transform.childCount > 0)
                         {
                             Debug.Log(transform.childCount);
                    
                            Destroy(transform.GetChild(0).gameObject);
                    
                         }

            }
            StopCoroutine("sendMj");//把协程停止
        }
        public void do8112(ByteBuffer buffer)
        {
            //服务器发送了13个int类型，代表13张牌，如果还有就一直接收，并用list保存
            while (buffer.Available > 0)
            {
                list.Add(buffer.readInt());
            }
            list.Sort();//这个是给list里的值按大小排序，系统的方法
            test();//用来开启协程，但是再这里无法直接调用，就用另一个函数手动调用
            

        }
        public void test()
        {
            StartCoroutine("sendMj");//开启协程
        }

        void Update () {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("点击位置---"+Input.mousePosition);
            }
        }
    }
}