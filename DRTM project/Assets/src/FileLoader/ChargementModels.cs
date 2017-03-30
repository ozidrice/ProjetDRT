using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChargementModels : MonoBehaviour {

	List<string> modeles = new List<string>();

	// Use this for initialization
	void Start () {
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


	void setModel(string modele) {
		Debug.Log (modele);
		GameObject go = GameObject.Find ("modele");
		if (go != null) {
			Destroy (go);
		}
		Debug.Log ("Le modele : " + modele);
		Object prefab = AssetDatabase.LoadAssetAtPath(modele, typeof(GameObject));
		GameObject clone = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		clone.name = "modele";
		if (modele == "Assets/Resources/Nedra.fbx") {
			clone.transform.position = new Vector3 (215f, -2019f, 342f);
			clone.transform.Rotate (new Vector3 (0f, 180f, 0f));
			clone.transform.localScale = new Vector3 (1300f, 1300f, 1300f);
			Destroy (GameObject.Find ("Nedra"));


		}

		else if (modele == "Assets/Resources/head1Free_FBX.fbx") {
			clone.transform.position = new Vector3 (366f, 180f, 0f);
			clone.transform.Rotate (new Vector3 (0f, 180f, 0f));
			clone.transform.localScale = new Vector3 (80f, 80f, 80f);
		}

		else if (modele == "Assets/Resources/textureSinge.fbx") {
			clone.transform.position = new Vector3 (-149.5f, 3.8f, 342f);
			clone.transform.Rotate (new Vector3 (-20.1f, -78.55f, 35.52f));
			clone.transform.localScale = new Vector3 (100f, 100f, 100f);
		}
		clone.gameObject.AddComponent(typeof(MouseRotation));
		clone.gameObject.GetComponent<MouseRotation> ().speed = 180;
		DontDestroyOnLoad(clone);
	}
}
