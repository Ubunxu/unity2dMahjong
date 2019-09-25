using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;//在Unity编辑下才能使用
/*
	项目名称：斗牛
	开发时间：2016/12/12
	作    者：pengxde
	版    本：DNV1.0
*/
namespace DNProject{
    public class BuilderRes : EditorWindow
    {

        [MenuItem("Tool/Build AssetBundles")]
        public static void builder()
        {
            BuilderRes pWin = (BuilderRes)EditorWindow.GetWindow(typeof(BuilderRes),true,"");
            
        }
        private string text=null;
        private string lable="";
        bool wf=true,af=false,of=false,webf=false;
        
        //绘制窗口时调用
        void OnGUI()
        {
            //输入框控件
            text = EditorGUILayout.TextField("请输入打包名字:", text);
            EditorGUILayout.LabelField(lable);

            wf = EditorGUILayout.ToggleLeft("Windows", wf);
            af = EditorGUILayout.ToggleLeft("Andriond", af);
            of = EditorGUILayout.ToggleLeft("iPhone", of);
            webf = EditorGUILayout.ToggleLeft("WebPlayer", webf);

            if (wf) targets[0] = BuildTarget.StandaloneWindows; else targets[0] = BuildTarget.Tizen;
            if (af) targets[1] = BuildTarget.Android; else targets[1] = BuildTarget.Tizen;
            if (of) targets[2] = BuildTarget.iOS; else targets[2] = BuildTarget.Tizen;
           

            if (GUILayout.Button("确定", GUILayout.Width(200)))
            {
                if (text==null || text.Trim().Length<=0)
                {
                    lable = "请输入打包名!";
                    return;
                }
                bool select = selectPKObject();
                if (!select)
                {
                    lable = "你还没有选择要打包的对象";
                    return;
                }
                startDB(text);
                this.Close();
            }
        }

        BuildTarget[] targets = new BuildTarget[4];
        void startDB(string _name)
        {
            if (targets[0] != BuildTarget.Tizen) runDB(_name + "_Windows",targets[0]);
            if (targets[1] != BuildTarget.Tizen) runDB(_name + "_Andriond",targets[1]);
            if (targets[2] != BuildTarget.Tizen) runDB(_name + "_Ios",targets[2]);

        }

        void runDB(string _name,BuildTarget _target)
        {
            AssetBundleBuild[] assetBundle = new AssetBundleBuild[1];
            assetBundle[0].assetBundleName = _name;// "MainFrameUI.res";
            int leng = list.Count;
            string[] sarr = new string[leng];
            for (int i = 0; i < leng; i++)
            {
                sarr[i] = list[i];
            }
            //string[] sarr = list.ToArray();
            assetBundle[0].assetNames = sarr;
            BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", assetBundle, BuildAssetBundleOptions.None,_target);
            Debug.Log(_name+" 打包成功!");
            //刷新编辑器
            AssetDatabase.Refresh();
        }
        
        /// <summary>
        /// 选择要打包的对象
        /// </summary>
        /// <returns></returns>
        ///
        List<string> list = new List<string>();
        bool selectPKObject()
        {
            list.Clear();
            Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
            if (SelectedAsset.Length <= 0) return false;
            foreach (Object obj in SelectedAsset)
            {
                string sourcePath = AssetDatabase.GetAssetPath(obj);
                list.Add(sourcePath);
            }
            return true;
        }
    }
}