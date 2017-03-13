using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChangementTexture : MonoBehaviour
{

    public string TextureFolderPath;

    // Use this for initialization
    void Start()
    {
        //LoadAllAssetAtPath
        //A refactor avec random sur dossier
        Material newMaterial;
        List<string> listTexturePath = new List<string>(); 
        
        foreach (string file in System.IO.Directory.GetFiles(TextureFolderPath))
        {
            if (file.EndsWith(".mat"))
            {
                listTexturePath.Add(file);
                print("Texture trouvée:" + file);
            }
        }
        int randomInt = Mathf.RoundToInt((listTexturePath.Count-1) * Random.value);
        print(listTexturePath.Count+" rand:"+randomInt);

        newMaterial = (Material)AssetDatabase.LoadAssetAtPath(listTexturePath[randomInt], typeof(Material));
        MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
        mesh.material = newMaterial;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
