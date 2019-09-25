using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using LitJson;
/// <summary>
/// @pxd
/// </summary>
namespace util
{
    /// <summary>
    /// 建议在Lua下使用
    /// </summary>
    public class JsonDataLua : JsonData
    {
        JsonDataLua json = null;
        private bool isAdd = false;
        public JsonDataLua()
        {
        }
        private JsonDataLua(JsonData data)
        {
            this.Add(data);
            isAdd = true;
        }
        public static JsonDataLua Parse(string _str)
        {
            //parentJsonDataLua = LitJson.JsonMapper.ToObject(_str);
            JsonDataLua json = new JsonDataLua(JsonMapper.ToObject(_str));
            //json.Add(LitJson.JsonMapper.ToObject(_str));
            return json;            
        }        
        public int getInt(string name)
        {
            return (int)this[0][name];
        }
        public string getString(string name)
        {
            return (string)this[0][name];
        }
        public float getFloat(string name)
        {
            return (float)this[0][name];
        }
        public double getDouble(string name)
        {
            return (double)this[0][name];
        }
        public JsonDataLua[] getArray(string name)
        {
            JsonDataLua[] arr = null;
            JsonData jd = this[0][name];
            if (jd.IsArray)
            {
                arr = new JsonDataLua[jd.Count];
                for (int i = 0; i < jd.Count; i++)
                {
                    JsonDataLua json = new JsonDataLua(jd[i]);
                    arr[i] = json;
                }
            }
            return arr;
        }
        public string ToJson()
        {
            if(isAdd)
            {
                return base[0].ToJson();
            }
            return base.ToJson();
        }

        public JsonDataLua getJsonDataLua(string name)
        {
            return new JsonDataLua(this[0][name]);
        }
        //==========================Add=====================/
        public void Add(string key,string value)
        {
            this[key] = value;
        }
        public void Add(string key, int value)
        {
            this[key] = value;
        }
        public void Add(string key, float value)
        {
            this[key] = value;
        }
        public object grt(string name)
        {
            return this[0][name];
        }
        
        public void Add(string key, double value)
        {
            this[key] = value;
        }
        public void Add(string key,object[] objs)
        {
            JsonData jd = new JsonData();
            foreach(object o in objs)
            {
                jd.Add(o);
            }
            this[key] = jd;
        }
    }
}
