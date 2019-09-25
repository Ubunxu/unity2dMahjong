using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
/*
	项目名称:王者荣耀
	开发时间:2018.08.08
	版本号:v1.0
	作者:pengxde
*/
namespace UnityGameEngine
{
	public class VisibleGroup 
	{
        public static List<GameObject> list = new List<GameObject>();
        static object Tobj = new object();
        public static void addGameObject(GameObject obj)
        {
            if (obj.tag != "enemy") return;
            lock(Tobj)
            {
                list.Add(obj);
            }
        }
        public static void removeGameObject(GameObject obj)
        {
            lock (Tobj)
            {
                list.Remove(obj);
            }
        }
        public static GameObject MinDistance(GameObject target,float dist)
        {
            int index = 0;
            float min = Vector3.Distance(target.transform.position, list[0].transform.position);
            for(int i=1;i<list.Count;i++)
            {
                if (list[i] == null) continue;
                float v = Vector3.Distance(target.transform.position, list[i].transform.position);
                if (min > v)
                {
                    min = v;
                    index = i;
                }
            }
            if (min > dist) return null;
            return list[index];
        }
	}
}
