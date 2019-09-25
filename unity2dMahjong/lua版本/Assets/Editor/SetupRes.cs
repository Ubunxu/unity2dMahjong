using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/*
	四川麻将
	时间:2017.6.12
	作者:风一样的程序员
	版本:2.6
*/
namespace SC_MahJong
{


    /// <summary>
    /// AssetBundle 专门用来进行打包,加载解压 的类
    /// </summary>
    public class SetupRes : Editor
    {
        [MenuItem("资源打包/Windows")]
        public static void builder1()
        {
            
            Debug.Log("你点击了菜单");
            BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.None,BuildTarget.StandaloneWindows64);
    
            AssetDatabase.Refresh();
        }
        [MenuItem("资源打包/Android")]
        public static void builder2()
        {
            
            Debug.Log("你点击了菜单");
            BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.None,BuildTarget.Android);
    
            AssetDatabase.Refresh();
        }
        [MenuItem("资源打包/IOS")]
        public static void builder3()
        {
            
            Debug.Log("你点击了菜单");
            BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.None,BuildTarget.iOS);
    
            AssetDatabase.Refresh();
        }
       

    }
}
