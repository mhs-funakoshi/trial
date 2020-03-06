using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode;


public class QRcodeReaderScript : MonoBehaviour
{
    public RawImage rawImage;
    WebCamTexture webCamTexture;
    // カメラからの映像と表示のアスペクト比を合わせる為に使う
    AspectRatioFitter aspectRatioFitter;
    GameObject Button;

    void Awake()
    {
      aspectRatioFitter = GetComponent<AspectRatioFitter>();
    }
    void Start()
    {
        this.Button = GameObject.Find("MainButton");
        webCamTexture = new WebCamTexture(Screen.currentResolution.width,
                                          Screen.currentResolution.height);
        rawImage.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.currentResolution.width,
                                                                       Screen.currentResolution.height);
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

            try
            {
                //QR読取処理。？非同期処理したい。？
                // 非同期処理した場合QRから抽出した文字列を
                // ボタンに繁栄できるか？
                IBarcodeReader barcodeReader = new BarcodeReader ();
                // decode the current frame
                var result = barcodeReader.Decode(webCamTexture.GetPixels32(), webCamTexture.width, webCamTexture.height);
                if (result != null) {
                    this.Button.GetComponentInChildren<Text>().text = result.Text;
                }
            } 
            catch
            { 
                Debug.LogWarning ("Error");
            }         
        }      
    }
}