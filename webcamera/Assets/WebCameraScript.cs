using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WebCameraScript : MonoBehaviour
{
    public RawImage rawImage;
    WebCamTexture webCamTexture;
    // カメラからの映像と表示のアスペクト比を合わせる為に使う
    AspectRatioFitter aspectRatioFitter;

    void Awake()
    {
      aspectRatioFitter = GetComponent<AspectRatioFitter>();
    }
    void Start()
    {
        webCamTexture = new WebCamTexture(Screen.currentResolution.width,Screen.currentResolution.height);
        rawImage.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.currentResolution.width,Screen.currentResolution.height);
        rawImage.texture = webCamTexture;
        webCamTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (webCamTexture?.isPlaying ?? false)
        {   
          // モバイルの縦持ち、横持ちに合わせてカメラ映像も回転
          transform.localEulerAngles = new Vector3(0, 0, -1 * (float) webCamTexture.videoRotationAngle);
          //カメラ映像のアスペクト比に表示も合わせる。  
          aspectRatioFitter.aspectRatio = (float)webCamTexture.width / (float)webCamTexture.height;            
            
        }      
    }
}
