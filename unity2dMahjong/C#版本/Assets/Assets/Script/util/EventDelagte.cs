using System.Collections;
using System.Collections.Generic;

/*
	四川麻将
	时间:2017.6.12
	作者:风一样的程序员
	版本:2.6
*/
namespace util
{
    
    [XLua.CSharpCallLua]
    public delegate void MyAction();
    [XLua.CSharpCallLua]
    public delegate void MyAction<T>(T obj);
    [XLua.CSharpCallLua]
    public delegate void MyAction2(object obj);
    [XLua.CSharpCallLua]
    public delegate void MyActionOne(object obj);//老师的

}
