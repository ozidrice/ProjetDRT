using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Controler : MonoBehaviour {

	public string filePath;
	List<string> modeles = new List<string>();

	// Use this for initialization
	void Start () {
		filePath = null;
		foreach (string file in System.IO.Directory.GetFiles("Assets/Resources/")) {
			if (file.EndsWith (".fbx")) {
				modeles.Add (file);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	void OnGUI()
	{
		float yOffset = 0f;

		foreach(string modele in modeles) {
			if( GUI.Button (new Rect (25, 25+ yOffset, 150, 30), modele) ) {
				setModel (modele);
			}
			yOffset += 35;
		}

	}

	void setFilePath(string file) {
		this.filePath = file;
		Debug.Log ("Controleur filepath : " + this.filePath);
	}

	void setModel(string modele) {
		GameObject go = GameObject.Find ("modele");
		if (go != null) {
			Destroy (go);
		}
		Debug.Log ("Le modele : " + modele);
		Object prefab = AssetDatabase.LoadAssetAtPath(modele, typeof(GameObject));
		GameObject clone = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		clone.name = "modele";
		clone.transform.position = new Vector3 (350f, -850f, 342f);
		clone.transform.Rotate(new Vector3 (0f, 180f, 0f));
		clone.transform.localScale = new Vector3 (600f, 600f, 300f);
	}
}
