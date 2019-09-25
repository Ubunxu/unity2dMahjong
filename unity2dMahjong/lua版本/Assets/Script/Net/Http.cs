using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
/*
	四川麻将
	时间:2017.6.12
	作者:风一样的程序员
	版本:2.6
*/
namespace util
{
    
    public class Http
    {
        public static void doGet(string url,MonoBehaviour parent, MyActionOne action =null)
        {
            parent.StartCoroutine(Connect(url, action,null));
        }

        public static void doPost(string url, MonoBehaviour parent, MyActionOne action = null, WWWForm form = null)
        {
            parent.StartCoroutine(Connect(url, action, form));
        }
        
        static IEnumerator Connect(string url, MyActionOne action =null,WWWForm form = null)
        {
            UnityWebRequest web = null;
            if(form==null)
            {
                web = UnityWebRequest.Get(url);
            }
            else
            {
                web = UnityWebRequest.Post(url, form);
            }
            web.timeout = 30;
            yield return web.SendWebRequest();
            if (web.isNetworkError)//超时
            {
                Debug.Log("连接超时");
            }
            else if (web.isHttpError)//其它情况
            {
                Debug.Log("连接出错: " + web.error);
            }
            else
            {
                if (action != null)
                {
                    action(web.downloadHandler.text);
                    action = null;
                }
            }
            web = null;
        }	
	}
}
