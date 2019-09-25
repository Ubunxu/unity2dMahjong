using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

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
    public static JsonData getJsonData(JsonData json, string key)
    {
        return json[key];
    }

    public static string ApplicationDatapath()
    {
        return Application.dataPath;
    }

    public static void writeFile(string path, byte[] bytes)
    {
        FileStream fs2 = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
        fs2.Write(bytes, 0, bytes.Length);
        fs2.Flush();
        fs2.Close();
    }

    public static void WriteFileByBytes(string path, byte[] bytes)
    {
        System.IO.File.WriteAllBytes(path, bytes);
    }
    public static void WriteFileByText(string path, string text)
    {

        System.IO.File.WriteAllText(path, text);
    }

    public static void CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }


    /*
        胡牌算法
         */
    public static bool IsCanHU(List<int> mah, int ID)
    {

        List<int> pais = new List<int>(mah);

        pais.Add(ID);

        //只有两张牌

        if (pais.Count == 2)

        {

            return pais[0] == pais[1];

        }

        //先排序

        pais.Sort();

        //依据牌的顺序从左到右依次分出将牌

        for (int i = 0; i < pais.Count; i++)
        {

            List<int> paiT = new List<int>(pais);

            List<int> ds = pais.FindAll(delegate (int d)
            {

                return pais[i] == d;

            });

            //判断是否能做将牌
            if (ds.Count >= 2)
            {

                //移除两张将牌

                paiT.Remove(pais[i]);

                paiT.Remove(pais[i]);

                //避免重复运算 将光标移到其他牌上

                i += ds.Count;

                if (HuPaiPanDin(paiT))
                {
                    return true;
                }

            }

        }

        return false;

    }

    // 除掉对子的牌听胡。
    private static bool HuPaiPanDin(List<int> mahs)
    {

        if (mahs.Count == 0)
        {

            return true;

        }

        List<int> fs = mahs.FindAll(delegate (int a)
        {

            return mahs[0] == a;

        });

        //组成克子

        if (fs.Count == 3)
        {

            mahs.Remove(mahs[0]);

            mahs.Remove(mahs[0]);

            mahs.Remove(mahs[0]);

            return HuPaiPanDin(mahs);

        }

        else
        { //组成顺子

            if (mahs.Contains(mahs[0] + 1) && mahs.Contains(mahs[0] + 2))
            {

                mahs.Remove(mahs[0] + 2);

                mahs.Remove(mahs[0] + 1);

                mahs.Remove(mahs[0]);

                return HuPaiPanDin(mahs);

            }

            return false;

        }

    }



}