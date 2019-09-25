using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	项目名称:王者荣耀
	开发时间:2018.08.08
	版本号:v1.0
	作者:pengxde
*/
namespace UnityGameEngine
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    /// <summary>
    /// 将脚本挂在摄像机观察的物体上  物体必须带有Render
    /// </summary>
    public class VisibleTT : MonoBehaviour
    {

        bool visible = false;
        bool visibleNo = false;
        bool isRendering;
        float curtTime = 0f;
        float lastTime = 0f;


        void OnWillRenderObject()
        {
            curtTime = Time.time;
        }
        public bool IsInView(Vector3 worldPos)
        {
            Transform camTransform = Camera.main.transform;
            Vector2 viewPos = Camera.main.WorldToViewportPoint(worldPos);
            Vector3 dir = (worldPos - camTransform.position).normalized;
            float dot = Vector3.Dot(camTransform.forward, dir);     //判断物体是否在相机前面

            if (dot > 0 && viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1)
                return true;
            else
                return false;
        }

        void Update()
        {
            Vector2 vec2 = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);

            if (IsInView(transform.position))
            {
                if (!visible)
                {
                    visible = true;
                    visibleNo = false;
                    //print("add: " + this.name);
                    VisibleGroup.addGameObject(this.gameObject);
                }
            }
            else
            {
                if (!visibleNo)
                {
                    visibleNo = true;
                    visible = false;
                    VisibleGroup.removeGameObject(this.gameObject);
                }
            }
        }
    }
}
