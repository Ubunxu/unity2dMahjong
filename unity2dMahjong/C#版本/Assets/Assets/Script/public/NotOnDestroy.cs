using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using util.net;

/*
四川麻将
时间：2017.6.12
作者：风一样的程序员
版本：2.6
*/
namespace SC_MahJong
{
    public class NotOnDestroy : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            this.gameObject.name = "foreverObject";
            DontDestroyOnLoad(this);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                util.Http.doGet(IP.HttpServer + "?type=1000&userName=xjy", this,(str)=> {
                    print("退出成功");
                });
                print("退出了。。。。。");
                
            }
        }

        private void OnDestroy()
        {
            //向服务器发起退出协议
            //util.Http.doGet(IP.HttpServer + "?type=1000&userName=xjy", this);
        }
    }
}

