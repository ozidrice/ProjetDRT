using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChangementTexture : MonoBehaviour
{
	public string TextureFolderPath;

    void Start()
    {
        //LoadAllAssetAtPath
        //A refactor avec random sur dossier
       /* Material newMaterial;
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
        mesh.material = newMaterial;*/


		//GameObject sp = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		/*GameObject go = new GameObject();
		go = (GameObject)Resources.Load ("Resources/Sphere");*/




		/*GameObject go = new GameObject();
		Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Resources/Nedra.fbx", typeof(GameObject));
		GameObject newModel = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		newModel.transform.SetParent = go;*/

		//System.IO.File.Copy( "/Users/yanis/OneDrive/Images/Inspo/nouveauNom.png", "/Users/yanis/OneDrive/Documents/GitHub/ProjetDRTM/DRTM project/Assets/test/" + "Nedra.png");

		//FileUtil.CopyFileOrDirectory("Users/yanis/Documents/IUT/Semestre 4/jeuVideo/ritm/Assets/noteReussie.png" , "Users/yanis/OneDrive/Documents/GitHub/ProjetDRTM/DRTM project/Assets/Resources" );
    }

    // Update is called once per frame
    void Update()
    {
		

	}

	void setModel(string modele) {
		//GameObject go = GameObject.Find ("model");
		//Destroy (go);
		Debug.Log ("Le modele : " + modele);
		Object prefab = AssetDatabase.LoadAssetAtPath(modele, typeof(GameObject));
		GameObject clone = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		clone.transform.position = new Vector3 (350f, -850f, 342f);
		clone.transform.Rotate(new Vector3 (0f, 180f, 0f));
		clone.transform.localScale = new Vector3 (600f, 600f, 300f);
	}

}