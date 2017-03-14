using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlerCanvas : MonoBehaviour {


    public Button selectFileButton;
    public Button passTo2DButton;   

    void Start()
    {
        selectFileButton.onClick.AddListener(launchSelectFile);
        passTo2DButton.onClick.AddListener(launch2D);
    }

    void launchSelectFile()
    {
        selectFileButton.SendMessage("filePanelOnClick");
    }

    void launch2D()
    {
        passTo2DButton.SendMessage("CaptureScreenshots");
    }
}
