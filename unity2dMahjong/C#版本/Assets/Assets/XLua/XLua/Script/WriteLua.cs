using UnityEngine;
using System.Collections;
using System.IO;
using XLua;
public class WriteLua : MonoBehaviour {
    string[] mjType = {"万","条","筒" };
    int[] typeId = {10,21,31 };
    string[] mjNum = { "一","二", "三", "四", "五", "六", "七", "八","九" };
	// Use this for initialization
	void Start () {
        FileStream luaFile = File.Create("Assets/Resources/MJConfig.lua.txt");
        string writeString = "MJConfig = {";
        byte[] byteString = System.Text.Encoding.UTF8.GetBytes(writeString);
        luaFile.Write(byteString, 0, byteString.Length);
        for (int k = 0; k < 3; k++)
        {
            string typeString = mjType[k];
            
            for (int j = 0; j < 9; j++)
            {
                string num = mjNum[j];
                string name = num + typeString;
                for (int i = 0; i < 4; i++)
                {
                    int id = (typeId[k] + j) * 10 + i;
                    writeString = "{ ['ID'] ='"+id+"',['名字']='"+ name + "',['路径']='路径'},\n";
                    byteString = System.Text.Encoding.UTF8.GetBytes(writeString);
                    luaFile.Write(byteString, 0, byteString.Length);
                }
            }
        }
        writeString = "}";
        byteString = System.Text.Encoding.UTF8.GetBytes(writeString);
        luaFile.Write(byteString, 0, byteString.Length);
        luaFile.Close();
        //for (int i = 1; i < 9; i++)
        //{
        //    for (int j = 1; j <= 4; j++)
        //    {

        //    }
        //}
    }
	
}
