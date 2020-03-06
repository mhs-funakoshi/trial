using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    GameObject mainbutton;
    QRcodeReaderScript qrcodescript;
    // Start is called before the first frame update
    void Start()
    {
        qrcodescript = GetComponent<QRcodeReaderScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClickScanButton()
    {
        SceneManager.LoadScene("QRcodeReaderScene");
    }

    public void OnClickHistoryButton()
    {
        SceneManager.LoadScene("HistoryScene");
    }

    public void OnClickBackButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickMainButton()
    {
        // 下記ではボタンのテキストを読込んで、それをOpenURLしている。
        // ？QRcodeReaderScriptから直接URLを受取れるようにしたい。？
        this.mainbutton = GameObject.Find("MainButton");
        string url = this.mainbutton.GetComponentInChildren<Text>().text;
        if (url != null) {
            Application.OpenURL(url);
        }
    }

    
}
