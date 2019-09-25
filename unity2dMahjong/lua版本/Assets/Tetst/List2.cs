using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
	四川麻将
	时间:2017.6.12
	作者:风一样的程序员
	版本:2.6
*/
namespace SC_MahJong
{
	public class List2 : MonoBehaviour {

        public Node[] nodes;
        public GameObject[] nodesObj;

		// Use this for initialization
		void Start ()
        {

    

            setValue5();

        }
		
        void setValue1()
        {
            //GameObject.Find("Canvas/Parents/Image/Text1").GetComponent<Text>().text = "lili1";
            //GameObject.Find("Canvas/Parents/Image/Text2").GetComponent<Text>().text = "lili2";

            //GameObject.Find("Canvas/Parents/Image2/Text1").GetComponent<Text>().text = "lili221";
            //GameObject.Find("Canvas/Parents/Image2/Text2").GetComponent<Text>().text = "lili22";

            //GameObject.Find("Canvas/Parents/Image3/Text1").GetComponent<Text>().text = "lili1333";
            //GameObject.Find("Canvas/Parents/Image3/Text2").GetComponent<Text>().text = "lili2333";

            //GameObject.Find("Canvas/Parents/Image4/Text1").GetComponent<Text>().text = "lili1444";
            //GameObject.Find("Canvas/Parents/Image4/Text2").GetComponent<Text>().text = "lili2555";

            this.transform.Find("Image/Text1").GetComponent<Text>().text = "lili1";
            this.transform.Find("Image/Text2").GetComponent<Text>().text = "lili1";
            this.transform.Find("Image").GetComponent<DownImage>().LoadImage("http://g.hiphotos.baidu.com/image/pic/item/86d6277f9e2f07084eacbbebe724b899a801f2b4.jpg");

            this.transform.Find("Image2/Text1").GetComponent<Text>().text = "lili12222";
            this.transform.Find("Image2/Text2").GetComponent<Text>().text = "lili12222";
            DownImage dm = this.transform.Find("Image2").GetComponent<DownImage>();
            dm.LoadImage("http://g.hiphotos.baidu.com/image/pic/item/86d6277f9e2f07084eacbbebe724b899a801f2b4.jpg");

            this.transform.Find("Image3/Text1").GetComponent<Text>().text = "lili13333";
            this.transform.Find("Image3/Text2").GetComponent<Text>().text = "lili33331";
            this.transform.Find("Image3").GetComponent<DownImage>().LoadImage("http://g.hiphotos.baidu.com/image/pic/item/86d6277f9e2f07084eacbbebe724b899a801f2b4.jpg");

            this.transform.Find("Image4/Text1").GetComponent<Text>().text = "lili14444";
            this.transform.Find("Image4/Text2").GetComponent<Text>().text = "lili15555";
            this.transform.Find("Image4").GetComponent<DownImage>().LoadImage("http://g.hiphotos.baidu.com/image/pic/item/86d6277f9e2f07084eacbbebe724b899a801f2b4.jpg");

            //print(this.transform.Find("Image/Text1").GetComponent<Text>().text);


        }

        void setValue2()
        {
            int childCount = this.transform.childCount;
            //print(childCount);
            for(int i=0;i<childCount;i++)
            {
                Transform child = this.transform.GetChild(i);
                child.Find("Text1").GetComponent<Text>().text = "lili11" + i;
                child.Find("Text2").GetComponent<Text>().text = "lili22" + i;
                child.GetComponent<DownImage>().LoadImage("http://g.hiphotos.baidu.com/image/pic/item/86d6277f9e2f07084eacbbebe724b899a801f2b4.jpg");
            }
        }

        void setValue3()
        {
            int childCount = this.transform.childCount;
            //print(childCount);
            for (int i = 0; i < childCount; i++)
            {
                Transform child = this.transform.GetChild(i);
                Node node = child.GetComponent<Node>();
                node.setValue("lili11" + i, "lili11" + i, "http://g.hiphotos.baidu.com/image/pic/item/86d6277f9e2f07084eacbbebe724b899a801f2b4.jpg");
            }
        }

        void setValue4()
        {
            for(int i = 0;i<nodes.Length;i++)
            {
                Node node = nodes[i];
                node.setValue("lili11555" + i, "lili55511" + i, "http://g.hiphotos.baidu.com/image/pic/item/86d6277f9e2f07084eacbbebe724b899a801f2b4.jpg");
            }
            //for(int j=0;j<nodesObj.Length;j++)
            //{
            //    Node node = nodesObj[j].GetComponent<Node>();
            //}
        }

        void setValue5()
        {
            Node[] nodes2 = this.transform.GetComponentsInChildren<Node>();
            for (int i = 0; i < nodes2.Length; i++)
            {
                Node node = nodes2[i];
                node.setValue("lili11" + i, "lili11" + i, "file://"+Application.dataPath+"/Tetst/testv.jpg");// "http://g.hiphotos.baidu.com/image/pic/item/86d6277f9e2f07084eacbbebe724b899a801f2b4.jpg");
                print(node.Text1 + "," + node.Text2 + "," + node.Image);
            }
        }


        // Update is called once per frame
        void Update () {
			
		}
	}
}
