using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textureDouble : MonoBehaviour {

	public ChangementTextureInterface typeChangementTexture;
	public string textureFolderPath	;
	private Material newMat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void appliquerDoubleTexture() {
		GameObject model = GameObject.Find("modeleDoubleTexture");
		Component[] meshs = model.gameObject.GetComponentsInChildren<MeshFilter>();

		if (model == null) {
			Debug.Log ("model introuvable");
		}

		foreach (Component obj in meshs) {
			if (obj.GetComponent<MeshFilter>() == true)
			try
			{
				typeChangementTexture = new ChangementTextureRandom();
				obj.GetComponent<MeshRenderer>().material = typeChangementTexture.getMat(textureFolderPath);
			}
			catch (MissingComponentException)
			{ }
		}
	}
}
