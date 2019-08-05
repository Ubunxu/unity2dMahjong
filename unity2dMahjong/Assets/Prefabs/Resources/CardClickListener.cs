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
    public class CardClickListener : MonoBehaviour
    {
        private static bool isUp = false;
        // Use this for initialization
        void Start()
        {
            print("点击牌，牌上升");
        }

        public void Move()
        {
            if (isUp)//上升了
            {
                //出牌（将自己牌面上的牌清除掉，然后放在桌子上）
                
            }
            else
            {
                print("上升了------");
                RectTransform rect = this.transform as RectTransform;
                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, 0f);
                isUp = true;
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}

