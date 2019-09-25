using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/*
四川麻将
时间：2017.6.12
作者：风一样的程序员
版本：2.6
*/
namespace SC_MahJong
{
    public class DoubleClickListener : MonoBehaviour
    {
        [Range(0, 0.5f)] 
        [SerializeField]
        private float mdelay=0.5f;
        private float firstClickTime=0;
        private bool isClick = false;
        private bool isHover=false;
        public UnityEvent Listener;
        private MyRoomView roomView;
        public static int count = -1;

     
        void OnMouseEnter()
        {
            isHover = true;
            print("hover....");
        }
        void OnMouseExit()
        {
            isHover = false;
        }

        void OnMouseUp()
        {
            print("onmouseup..........");
            if (isClick==false)
            {
                isClick = true;
                firstClickTime = Time.time;
                return;
            }
            if (isClick)
            {
                ++count;
                //代表双击了（将选中的牌打到发牌区)
                print("双击了=====" + count);
                string cardName = this.name.Replace('b', 's');

                MyClone(this.roomView.mjSpriteDic, cardName, count);

                Listener.Invoke();
            
            }
        }

        private void MyClone(Dictionary<string, Sprite> mjSpriteDic, string cardName, int i)
        {
            GameObject mjObj = Instantiate(Resources.Load("DMahjong0")) as GameObject;
            mjObj.transform.SetParent(GameObject.Find("Panel/bottom/sendMahjong").transform, false);

            (mjObj.transform as RectTransform).anchoredPosition = new Vector2(-247.5f + 55 * i, 42f);
            mjObj.transform.GetComponent<Image>().sprite = mjSpriteDic[cardName];
        }
        // Use this for initialization
        void Start()
        {
            this.roomView = GameObject.Find("Canvas").transform.GetComponent<MyRoomView>();
            print("majiang--------");
        }

        // Update is called once per frame
        void Update()
        {
            if (isHover)
            {
                if (Time.time - firstClickTime > mdelay)
                {
                    isClick = false;
                }
            }
        }
    }
}

