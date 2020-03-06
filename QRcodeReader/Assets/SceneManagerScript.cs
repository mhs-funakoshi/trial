using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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

    
}
