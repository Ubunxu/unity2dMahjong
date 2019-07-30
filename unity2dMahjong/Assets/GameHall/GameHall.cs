using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
四川麻将
时间：2017.6.12
作者：风一样的程序员
版本：2.6
*/
namespace SC_MahJong
{
    public class GameHall : MonoBehaviour
    {
        string[] images = new string[12];
        string[] inputTexts = new string[6];
        private int count = 0;//输入号码的个数
        private string passwordStr;
        // Use this for initialization
        void Start()
        {
            this.transform.Find("Panel/left/joinRoomButt").GetComponent<Button>().onClick.AddListener(() =>
            {
                //跳转到加入房间的页面。
                this.transform.Find("AddRoom").gameObject.SetActive(true);
                //InitData();
                //InitClickNumber();
            });

            this.transform.Find("Panel/left/createRoomButt").GetComponent<Button>().onClick.AddListener(() =>
            {
                this.transform.Find("CreateRoom").gameObject.SetActive(true);

            });

        }

        private void InitData()
        {

            for (int i = 0; i < 12; ++i)
            {
                images[i] = "image" + i;
            }
            for (int i = 0; i < 6; ++i)
            {
                inputTexts[i] = "/Text" + i;
            }
        }
        private void InitClickNumber()
        {

            for (int i = 0; i < 10; ++i)
            {
                Button button = this.transform.Find("AddRoom/Panel/bgImage/LineContent/line3/" + images[i]).GetComponent<Button>();
                button.onClick.AddListener(() =>
                {
                    string strNUm = button.name.Substring(5);
                    InputNumber(int.Parse(strNUm));
                });
            }

        }

        private void InputNumber(int i)
        {

            if (i >= 0 && i <= 9)
            {
                    print("-------------");
                if (count <= 5)
                {

                    this.transform.Find("AddRoom/Panel/bgImage/LineContent/line2/input" + count + inputTexts[count]).gameObject.GetComponent<Text>().text = i.ToString();
                    if (count == 5)
                    {
                        passwordStr += i.ToString();
                        //验证密码。
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            else if (i == 10)//清空
            {
                print("i===10");
            }
            else if (i == 11)//删除
            {
                print("i===11");
            }
        }
        


        // Update is called once per frame
        void Update()
        {

        }
    }
}

