using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FileFinder : MonoBehaviour
{

    public Button button;
    public Text filePathText;
    private string path;
    private static string NOFILESTRING = "No file selected.";
    void Start()
    {
        button.onClick.AddListener(filePanelOnClick);
        Debug.Log("Path button launched...");
        filePathText.text = NOFILESTRING;
    }

    void filePanelOnClick()
    {
        Debug.Log("clicked");
        this.path = EditorUtility.OpenFilePanel("Select a file","","fbx");
        if (path.Length == 0)
            this.path = NOFILESTRING;
        filePathText.text = this.path;
        Debug.Log("Link is :" + this.path);
    }

    string getPath()
    {
        if (this.path.Length == 0)
            throw new NoFileException();
        return this.path;
    }
}


internal class NoFileException : Exception
{
    public NoFileException()
    {
    }

    public NoFileException(string message) : base(message)
    {
    }

    public NoFileException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected NoFileException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}