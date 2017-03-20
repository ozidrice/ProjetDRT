using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlerCanvas : MonoBehaviour {


    public Button selectFileButton;
    public Button passTo2DButton;
    public Button RandomTexture;
    public GameObject model; 

    void Start()
    {
        if(selectFileButton != null)
            selectFileButton.onClick.AddListener(launchSelectFile);
        if(passTo2DButton != null)
            passTo2DButton.onClick.AddListener(launch2D);
        if (RandomTexture != null && model != null)
            RandomTexture.onClick.AddListener(changerTexture);
    }

    void changerTexture()
    {
        this.model.SendMessage("appliquerTexture");
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
