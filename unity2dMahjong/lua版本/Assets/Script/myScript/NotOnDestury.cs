using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.UI;

namespace D3_Project
{
    public class NotOnDestury : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            this.gameObject.name = "ForEveryObject";
            DontDestroyOnLoad(this);
        }


        void Update()
        {
            if(Input.GetMouseButtonDown(1))
            {
                util.Http.doGet(util.net.IP.HttpServer+"?type=1000&userName=xujy", this);
                print("退出登录");
            }

           
        }
        // Update is called once per frame
        void OnDestroy()
        {

        }
    }
}
