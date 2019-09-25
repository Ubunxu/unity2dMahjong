using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
/*
	四川麻将
	时间:2017.6.12
	作者:风一样的程序员
	版本:2.6
*/
namespace util
{
    /// <summary>
    /// xml加载器，用来加载游戏中所有需要用到的xml文件
    /// </summary>
	public class XMLLoader
    {
        //保存所有加载的xml文件
        private static Dictionary<string, XmlDocument> xmls = new Dictionary<string, XmlDocument>();
        //队列
        private static Queue<xmlNode> queueNode = new Queue<xmlNode>();
        //当前是不是正在加载
        private static bool loading = false;
        //线程程
        private static object lockObj = new object();

        private static XMLLoader instance = new XMLLoader();
        private MyAction allLoadComplateAction = null;
        /// <summary>
        /// 开始加载xml
        /// </summary>
        /// <param name="filename">要加载xml路径，可以是远程服务器路径，也可以是本地路径</param>
        /// <param name="action">加载完以后的回调方法，带一个XmlElement参数，内容为：加载完以后的xml的根节点</param>
        /// <param name="isSave">加载完以后要不要保存，保存后方便后面的场景使用</param>
        /// <param name="otherName">加载完以后，可以自己定义一个名字来保存</param>
        public static XMLLoader LoadXML(string filename,MonoBehaviour parent, MyAction<XmlElement> action=null, bool isSave = true,string otherName=null)
        {
            lock(lockObj)
            {
                xmlNode node;
                node.filename = filename;
                node.parent = parent;
                node.action = action;
                node.isSave = isSave;
                node.otherName = otherName;
                queueNode.Enqueue(node);
            }
            startTask();
            return instance;
        }
        public static XMLLoader LoadXML(string[] filename, MonoBehaviour parent, MyAction<XmlElement> action = null, bool isSave = true, string otherName = null)
        {
            lock(lockObj)
            {
                foreach (string str in filename)
                {
                    xmlNode node;
                    node.filename = str;
                    node.parent = parent;
                    node.action = action;
                    node.isSave = isSave;
                    node.otherName = otherName;
                    //添加到队列
                    queueNode.Enqueue(node);
                }
            }
            startTask();
            return instance;
        }
        static void startTask()
        {
            //判断要不要启动
            if (!loading)
            {
                loading = true;
            }
            NextLoad();
        }
        static void NextLoad()
        {
            if (queueNode.Count <= 0)
            {
                loading = false;
                if (instance.allLoadComplateAction != null)
                {
                    instance.allLoadComplateAction();
                    instance.allLoadComplateAction = null;
                }
            }
            lock (lockObj)
            {                
                //从队列中取出一个内容
                if (queueNode.Count > 0)
                {
                    xmlNode node;
                    node = queueNode.Dequeue();
                    node.parent.StartCoroutine(Load(node));
                }                
            }            
        }
        static IEnumerator Load(xmlNode node)
        {
            WWW www = new WWW(node.filename);
            yield return www;
            if(www.error==null || www.error.Length<=0)
            {
                string xmlstr = www.text;
                www = null;
                LoadResult(xmlstr,node);
            }
            else
            {
                Debug.Log("加载出错： " + www.error);
                www = null;
            }            
        }
        //http://..../data.xml
        static void LoadResult(string str,xmlNode node)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(str);
            //要不要保存
            if (node.isSave)
            {
                //得到要保存的文件名
                string saveName = node.otherName;
                if (saveName == null)
                {
                    int s = node.filename.LastIndexOf('/') + 1;
                    int e = node.filename.LastIndexOf('.');
                    saveName = node.filename.Substring(s,e-s);
                }
                xmls.Add(saveName, xml);
            }
            //有没有回调
            if (node.action != null)
            {
                node.action(xml.DocumentElement);                
            }
            Debug.Log(node.filename);
            node.Clear();
            NextLoad();
        }

        public void onAllComplate(MyAction myAction)
        {
            allLoadComplateAction = myAction;
        }

        //获得xml文档对象
        public static XmlDocument getXMLDocument(string name)
        {
            if(xmls.ContainsKey(name))
            {
                return xmls[name];
            }
            return null;
        }
        //获得节点
        public static XmlElement getRoot(string name)
        {
            if (xmls.ContainsKey(name))
            {
                return xmls[name].DocumentElement;
            }
            return null;
        }
    }
    struct xmlNode
    {
        public string filename;
        public MonoBehaviour parent;
        public MyAction<XmlElement> action;
        public bool isSave;
        public string otherName;
        public void Clear()
        {
            filename = null;
            parent = null;
            action = null;
            isSave = false;
            otherName = null;
        }
    }

}
