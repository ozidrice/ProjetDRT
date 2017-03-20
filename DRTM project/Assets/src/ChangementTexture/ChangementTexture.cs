using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangementTexture : MonoBehaviour
{

    public GameObject[] models;
    public string textureFolderPath;
    private Material newMat;
    public ChangementTextureInterface typeChangementTexture;


    void Start()
    {
       
    }


    void appliquerTexture()
    {
        typeChangementTexture = new ChangementTextureRandom();
        newMat = typeChangementTexture.getMat(textureFolderPath);
        foreach (GameObject obj in models)
        {
            try
            {
                obj.GetComponent<MeshRenderer>().material = newMat;
            }
            catch (MissingComponentException)
            { }
        }
    }
}
