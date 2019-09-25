using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Xml;
/*
	功能：加载管理器
    版本: v2.6
    时间: 2019.8.22
    Auther: xxxxxxxx
*/
namespace util
{
    public class LoadFactory
    {
        private static Dictionary<string, object> dict = new Dictionary<string, object>();
        private static Queue<loadNode> paths = new Queue<loadNode>();
        private static WWW www = null;
        private static string loadText = null;
        private static MyAction loadAllComplate = null;
        private static LoadFactory instance = new LoadFactory();

        public static LoadFactory LoadAssetWwwBytes(string path, MonoBehaviour parent, MyActionTwo action = null, bool isSave = false)
        {
            LoadFactory.innerLoad(path, parent, action, isSave, loadType.Wwwbytes);
            return instance;
        }

        public static LoadFactory LoadAssetWwwBytes(string[] path, MonoBehaviour parent, MyActionTwo action = null, bool isSave = false)
        {
            LoadFactory.innerLoad(path, parent, action, isSave, loadType.Wwwbytes);
            return instance;
        }

        public static LoadFactory LoadAssetBundle(string path, MonoBehaviour parent, MyActionTwo action = null, bool isSave = false)
        {
            LoadFactory.innerLoad(path, parent, action, isSave, loadType.AssetBundle);
            return instance;
        }

        public static LoadFactory LoadAssetBundle(string[] path, MonoBehaviour parent, MyActionTwo action = null, bool isSave = false)
        {
            LoadFactory.innerLoad(path, parent, action, isSave, loadType.AssetBundle);
            return instance;
        }

        public static LoadFactory LoadAssetTextrue(string path, MonoBehaviour parent, MyActionTwo action = null, bool isSave = false)
        {
            LoadFactory.innerLoad(path, parent, action, isSave, loadType.Texture);
            return instance;
        }
        public static LoadFactory LoadAssetTextrue(string[] path, MonoBehaviour parent, MyActionTwo action = null, bool isSave = false)
        {
            LoadFactory.innerLoad(path, parent, action, isSave, loadType.Texture);
            return instance;
        }

        public static LoadFactory LoadAssetText(string path, MonoBehaviour parent, MyActionTwo action = null, bool isSave = false)
        {
            LoadFactory.innerLoad(path, parent, action, isSave, loadType.Text);
            return instance;
        }
        public static LoadFactory LoadAssetText(string[] path, MonoBehaviour parent, MyActionTwo action = null, bool isSave = false)
        {
            LoadFactory.innerLoad(path, parent, action, isSave, loadType.Text);
            return instance;
        }

        public static LoadFactory LoadAsset(string path, MonoBehaviour parent, MyActionTwo action = null, bool isSave = false, loadType type = loadType.None)
        {
            LoadFactory.innerLoad(path, parent, action, isSave, type);
            return instance;
        }
        public static LoadFactory LoadAsset(string[] path, MonoBehaviour parent, MyActionTwo action = null, bool isSave = false, loadType type = loadType.None)
        {
            LoadFactory.innerLoad(path, parent, action, isSave, type);
            return instance;
        }
        private static void innerLoad(string[] path, MonoBehaviour parent, MyActionTwo action = null, bool isSave = false, loadType type = loadType.None)
        {
            foreach (string p in path)
            {
                loadNode node;
                node.path = p;
                node.parent = parent;
                node.action = action;
                node.isSave = isSave;
                node.type = type;
                paths.Enqueue(node);
            }
            LoadFactory.NextLoad();
        }
        private static void innerLoad(string path, MonoBehaviour parent, MyActionTwo action = null, bool isSave = false, loadType type = loadType.None)
        {
            loadNode node;
            node.path = path;
            node.parent = parent;
            node.action = action;
            node.isSave = isSave;
            node.type = type;
            paths.Enqueue(node);
            LoadFactory.NextLoad();
        }
        private static void NextLoad()
        {
            if (paths.Count > 0)
            {
                loadNode node = paths.Dequeue();
                node.parent.StartCoroutine(DownLoad(node));
            }
            else
            {
                if (loadAllComplate != null)
                {
                    loadAllComplate();
                    loadAllComplate = null;
                }
            }
        }

        static IEnumerator DownLoad(loadNode node)
        {
            LoadFactory.loadText = node.path;
            LoadFactory.www = new WWW(node.path);
            yield return LoadFactory.www;
            if (string.IsNullOrEmpty(LoadFactory.www.error))
            {
                loadType type = node.type;
                switch (type)
                {
                    case loadType.Wwwbytes:
                        LoadFactory.ParseObject(node, LoadFactory.www.bytes);
                        break;
                    case loadType.AssetBundle:
                        LoadFactory.ParseObject(node, LoadFactory.www.assetBundle);
                        break;
                    case loadType.Texture:
                        LoadFactory.ParseObject(node, LoadFactory.www.texture);
                        break;
                    case loadType.Text:
                        LoadFactory.ParseObject(node, LoadFactory.www.text);
                        break;
                    case loadType.Xml:
                        LoadFactory.ParseXML(node, LoadFactory.www.text);
                        break;
                    case loadType.AudioClip:
                        LoadFactory.ParseObject(node, LoadFactory.www.GetAudioClip());
                        break;
                }
                //LoadFactory.www = null;
                //Debug.Log("loadFactory.www>>>>>>>>>>>>>>>  ");
                LoadFactory.loadText = "加载完成";
                LoadFactory.NextLoad();
            }
            else
            {
                // LoadFactory.www = null;
                LoadFactory.loadText += " - 加载出错:" + www.error;
                Debug.Log("加载出错: " + www.error);
                LoadFactory.NextLoad();
            }
        }

        static void ParseObject(loadNode node, object obj)
        {
            if (node.isSave)
            {
                string saveName = node.path.Substring(node.path.LastIndexOf('/') + 1);
                dict.Add(saveName, obj);
            }
            if (node.action != null)
            {
                //AssetBundle ab =  ((DownloadHandlerAssetBundle)(request.downloadHandler)).assetBundle;   
                if(node.type==loadType.AssetBundle)
                {
                    LoadFactory.www.assetBundle.Unload(false);
                }
                node.action(obj,LoadFactory.www.bytes);
            }
        }
        static void ParseXML(loadNode node, string xmlstr)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlstr);
            if (node.isSave)
            {
                string saveName = node.path.Substring(node.path.LastIndexOf('/') + 1);
                dict.Add(saveName, xmldoc);
            }
            if (node.action != null)
            {
                //AssetBundle ab =  ((DownloadHandlerAssetBundle)(request.downloadHandler)).assetBundle;                    
                node.action(xmldoc, LoadFactory.www.bytes);
            }
        }
        /// <summary>
        /// 取出以后，要不要删除
        /// </summary>
        /// <typeparam name="T">返回的类型</typeparam>
        /// <param name="name">键</param>
        /// <param name="isDel">取完以后要不要删除，fale:不删除，true:删除</param>
        /// <returns></returns>
        public static T Get<T>(string name, bool isDel = false)
        {
            if (dict.ContainsKey(name))
            {
                T t = (T)dict[name];
                if (isDel)
                {
                    dict.Remove(name);
                }
                return t;
            }
            return default(T);
        }
        /// <summary>
        /// 获得当前正在加载的进度，可以用来作进度条的值
        /// </summary>
        public static float progress
        {
            get
            {
                if (www != null) return www.progress;
                return 0;
            }
        }
        /// <summary>
        /// 获得当前正在加载的内容路径，可以显示在进度条中的文本上
        /// </summary>
        public static string Text
        {
            get
            {
                if (www != null) return loadText;
                return "";
            }
        }
        /// <summary>
        /// 当所有内容加载完以后的回调，告诉外部，全部加载完了
        /// </summary>
        /// <param name="action"></param>
        public void doComplate(MyAction action)
        {
            LoadFactory.loadAllComplate = action;
        }
    }


    struct loadNode
    {
        public string path;
        public MonoBehaviour parent;
        public bool isSave;
        public MyActionTwo action;
        public loadType type;
    }

    public enum loadType
    {
        Wwwbytes,
        Xml,
        AssetBundle,
        Texture,
        AudioClip,
        Text,
        None
    }
}
