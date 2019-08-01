using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DownImage : MonoBehaviour {

    public string imgUrl;
	// Use this for initialization
  	void Start () {
        
	}
    public void setImage(string img)
    {
        imgUrl = img;
        StartCoroutine(down());
    }
    public void LoadImage(string img)
    {
        imgUrl = img;
        StartCoroutine(down());
    }

    private IEnumerator down()
    {
        WWW www = new WWW(imgUrl);
        yield return www;
        if(string.IsNullOrEmpty(www.error))
        {
            GetComponent<RawImage>().texture = www.texture;
        }
        www = null;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
