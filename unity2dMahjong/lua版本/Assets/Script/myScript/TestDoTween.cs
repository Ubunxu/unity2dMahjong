using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace D3_Project
{
    public class TestDoTween : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            //Vector3
            //(this.transform as RectTransform).DOAnchorPosX(500, 3f);
            //(this.transform as RectTransform).DOScale(0.5f, 3f);
            //(this.transform as RectTransform).DOLocalRotate(new Vector3(0, 0, 180), 1f).SetLoops(-1);
            //this.transform.GetComponent<Image>().DOColor(Color.red, 2);

            Sequence s = DOTween.Sequence();
            s.Append(this.transform.DOMoveX(7, 3f));
            //s.AppendInterval(1);
            //s.Append(this.transform.DORotate(new Vector3(0, 280, 0), 3f));
            //s.AppendInterval(1);
            //s.Append(this.transform.GetComponent<MeshRenderer>().material.DOColor(Color.red, 3f));
            //s.AppendInterval(1);
            //s.AppendCallback(Test1);
            //s.AppendInterval(1);
            //s.OnComplete(() => { print("执行完了"); });

            List<Vector3> list = new List<Vector3>();
           
            foreach(Transform obj in GameObject.Find("Plane").transform)
            {
                list.Add(obj.position);
            }
            for(int i=0;i<list.Count;i++)
            {
                s.Append(this.transform.DOLookAt(list[i], 0.1f));
                s.Append(this.transform.DOMove(list[i], 3f));
            }
            s.OnComplete(() => { print("游戏胜利！"); });

        }

        // Update is called once per frame
        void Update()
        {
            
        }
        void Test1()
        {
            print("Test1");
        }
    }
}
