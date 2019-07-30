using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace util.core
{
    public class EventDispatch
    {
        public delegate void windowCall(int methodName, params object[] objs);

        static windowCall wCall = null;
        static Dictionary<int, Node> dict = new Dictionary<int, Node>();
        public static void addEventListener(string className, string priex = "do")
        {
            //1：根据字符串类名 获得该类的类型
            Type type = Type.GetType(className);//线程.A, 线程.B
                                                //2：创建对象
            object parent = Activator.CreateInstance(type);//new A();
                                                    //获得所有方法,返回一个方法数组
                                                    //MethodInfo m = type.GetMethod("do1001");
            MethodInfo[] ms = type.GetMethods();
            //取出所有指定开头的方法
            for (int i = 0; i < ms.Length; i++)
            {
                MethodInfo mth = ms[i];
                if (mth.Name.StartsWith(priex))
                {
                    Node node = new Node(parent,mth);
                    int sName = int.Parse(mth.Name.Substring(priex.Length));
                    dict.Add(sName, node);
                    //Console.WriteLine(mth.Name);
                }
            }
        }
        public static void addEventListener(object p, string priex = "do")
        {
            //1：根据字符串类名 获得该类的类型
            Type type = p.GetType();// Type.GetType(className);//线程.A, 线程.B
                                    //2：创建对象
            object parent = p;// Activator.CreateInstance(type);//new A();
                                                           //获得所有方法,返回一个方法数组
                                                           //MethodInfo m = type.GetMethod("do1001");
            MethodInfo[] ms = type.GetMethods();
            //取出所有指定开头的方法
            for (int i = 0; i < ms.Length; i++)
            {
                MethodInfo mth = ms[i];
                if (mth.Name.StartsWith(priex))
                {
                    Node node = new Node(parent, mth);
                    int sName = int.Parse(mth.Name.Substring(priex.Length));
                    if(!dict.ContainsKey(sName))
                    {
                        dict.Add(sName, node);
                        //Console.WriteLine(mth.Name);
                    }
                   
                }
            }
        }
        public static void dispatchEvent(int methodName,params object[] objs)
        {
            if (dict.ContainsKey(methodName))
            {
                Node node = dict[methodName];
                node.Run(objs);
            }
            else
            {
                UnityEngine.Debug.Log("错误的协议类型： " + methodName);
            }
        }
        public static void Remove(int key)
        {
            dict.Remove(key);
        }
        public static void Remove(object p, string priex)
        {
            //1：根据字符串类名 获得该类的类型
            Type type = p.GetType();// Type.GetType(className);//线程.A, 线程.B
                                    //2：创建对象
            object parent = p;// Activator.CreateInstance(type);//new A();
                              //获得所有方法,返回一个方法数组
                              //MethodInfo m = type.GetMethod("do1001");
            MethodInfo[] ms = type.GetMethods();
            //取出所有指定开头的方法
            for (int i = 0; i < ms.Length; i++)
            {
                MethodInfo mth = ms[i];
                if (mth.Name.StartsWith(priex))
                {
                    int sName = int.Parse(mth.Name.Substring(priex.Length));
                    if (dict.ContainsKey(sName))
                    {
                        dict.Remove(sName);
                    }
                }
            }
        }
        public static void Remove(string className, string priex)
        {
            //1：根据字符串类名 获得该类的类型
            Type type = Type.GetType(className);//线程.A, 线程.B
                                    //2：创建对象
            object parent = Activator.CreateInstance(type);//new A();
                              //获得所有方法,返回一个方法数组
                              //MethodInfo m = type.GetMethod("do1001");
            MethodInfo[] ms = type.GetMethods();
            //取出所有指定开头的方法
            for (int i = 0; i < ms.Length; i++)
            {
                MethodInfo mth = ms[i];
                if (mth.Name.StartsWith(priex))
                {
                    int sName = int.Parse(mth.Name.Substring(priex.Length));
                    if (dict.ContainsKey(sName))
                    {
                        dict.Remove(sName);
                    }
                }
            }
        }
    }
    class Node
    {
        public object parent;
        public MethodInfo method;

        public Node(object parent, MethodInfo method)
        {
            this.parent = parent;
            this.method = method;
        }
        public void Run(params object[] objs)
        {
            this.method.Invoke(this.parent, objs);
        }
    }
}