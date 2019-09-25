using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace util
{
    [XLua.CSharpCallLua]
    public delegate void MyAction();
    [XLua.CSharpCallLua]
    public delegate void MyAction<T>(T obj,byte[] bytes=null);
    [XLua.CSharpCallLua]
    public delegate void MyActionTwo(object obj, byte[] bytes = null);
    [XLua.CSharpCallLua]
    public delegate void MyActionOne(object obj);
}
