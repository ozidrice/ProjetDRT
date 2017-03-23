using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LoadAllToScrollView : MonoBehaviour {
    public string pathToMaterials;
	// Use this for initialization
	void Start () {
		List<string> listTexturePath = new List<string>();
        foreach (string file in System.IO.Directory.GetFiles(pathToMaterials))
        {
            string fileName = file.ToLowerInvariant();
            if (fileName.EndsWith(".png"))
            {
                listTexturePath.Add(file);
                Debug.Log("Texture trouvée:" + file);
            }
        }

        foreach (string path in listTexturePath) {
            GameObject go = new GameObject();
            Image img = go.AddComponent<Image>();
            Sprite newSprite = Resources.Load<Sprite>(path);
            if (newSprite)
            {
                img.sprite = newSprite;
            }
            else
            {
                Debug.Log(path);
                Debug.LogError("Sprite not found", this);
            }
            img.sprite = newSprite;
            img.transform.SetParent(this.transform);
        }
  	}
	
}
