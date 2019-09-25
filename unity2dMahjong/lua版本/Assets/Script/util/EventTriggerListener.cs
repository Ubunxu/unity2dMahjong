using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using XLua;
/// <summary>
/// 这是一个仿照NGUI开发的对象点击事件系统，方便操作
/// </summary>


public class EventTriggerListener : UnityEngine.EventSystems.EventTrigger
{
    [CSharpCallLua]
    public delegate void VoidDelegate(GameObject go);
    public VoidDelegate onClick;
    public VoidDelegate onDown;
    public VoidDelegate onEnter;
    public VoidDelegate onExit;
    public VoidDelegate onUp;
    public VoidDelegate onSelect;
    public VoidDelegate onUpdateSelect;
    //static Dictionary<string, UnityEngine.UI.Button> dict = new Dictionary<string, UnityEngine.UI.Button>();
    public static EventTriggerListener Get(GameObject go)
    {
        EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
        if (listener == null) listener = go.AddComponent<EventTriggerListener>();
        return listener;
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onClick != null) onClick(gameObject);
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (onDown != null) onDown(gameObject);
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (onEnter != null) onEnter(gameObject);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (onExit != null) onExit(gameObject);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (onUp != null) onUp(gameObject);
    }
    public override void OnSelect(BaseEventData eventData)
    {
        if (onSelect != null) onSelect(gameObject);
    }
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (onUpdateSelect != null) onUpdateSelect(gameObject);
    }
    /*void Awake()
    {
        UnityEngine.UI.Button button = this.GetComponent<Button>();
        if (dict.ContainsKey(this.name))
        {
            dict.Remove(this.name);
        }
        dict.Add(this.name, button);
    }*/
    /// <summary>
    /// 用此方法的注意：必须要先将该类绑定在该对象身上，否则无效
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
  //  static public EventTriggerListener GetName(string name)
  //  {
		///*
  //      GameObject go;
  //      if (!dict.ContainsKey(name))
  //      {
  //          go = GameObject.Find(name);
  //      }
  //      else go = dict[name].gameObject;*/
  //      EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
  //      if (listener == null) listener = go.AddComponent<EventTriggerListener>();
  //      return listener;
  //  }
}