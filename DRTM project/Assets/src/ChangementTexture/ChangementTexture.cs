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
       
        typeChangementTexture = new ChangementTextureRandom();
        newMat = typeChangementTexture.getMat(textureFolderPath);
        foreach (GameObject obj in models)
        {
            appliquerTexture(newMat,obj);
        }

    }


    void appliquerTexture(Material mat, GameObject obj)
    {
        try
        {
            obj.GetComponent<MeshRenderer>().material = mat;
        }
        catch (MissingComponentException)
        {}
    }
}
