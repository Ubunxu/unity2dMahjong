using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace util
{
    public class Logger
    {
        public static void wanr(params object[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach(object o in args)
            {
                sb.Append(o.ToString());
                sb.Append(",");
            }
            UnityEngine.Debug.Log(sb.ToString());
        }
        public static void wanrln(params object[] args)
        {            
            foreach (object o in args)
            {
                UnityEngine.Debug.Log(o.ToString());
            }            
        }
    }

}
