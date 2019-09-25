using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoginAndReg : MonoBehaviour {


	// Use this for initialization
	void Start ()
    {
        //Find:用来找子节点
        this.transform.Find("login/btn_toreg").GetComponent<Button>().onClick.AddListener(doReg);

        /*
            代码挂在谁身上，this就代表谁，同时this也代表当前类的对象
            transform:代表当前物体对象的数据，当前物体身上的所有组件都可以通过transform来获得
            Transform tr = this.transform.Find(子节点路径或名字)
            通过transform物体数据得到对象方法为: transform.gameObject
            
        */



    }
    public void doReg()
    {
        this.transform.Find("login").gameObject.SetActive(false);
        this.transform.Find("reg").gameObject.SetActive(true);
        


    }


	// Update is called once per frame
	void Update () {
		
	}
}
