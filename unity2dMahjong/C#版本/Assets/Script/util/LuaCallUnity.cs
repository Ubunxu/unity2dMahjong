using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

/// <summary>
/// 实现一些Lua中无法实现Unity中的功能的方法
/// Lua中调用Unity中的方法
/// </summary>
public class LuaCallUnity
{
    /// <summary>
    /// 射线检测
    /// </summary>
    /// <param name="cam"></param>
    /// <param name="pos"></param>
    /// <param name="maxDisct"></param>
    /// <returns></returns>
    public static RaycastHit RayCastForCamera(Camera cam, Vector3 pos, float maxDisct = 100)
    {
        Ray ray = cam.ScreenPointToRay(pos);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, maxDisct);
       
        return hit;
    }

    /// <summary>
    /// [弃用的]获取jsondata的value,
    /// </summary>
    /// <param name="data"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static JsonData GetJsonData(JsonData data,string key)
    {
        return data[key];
    }

}