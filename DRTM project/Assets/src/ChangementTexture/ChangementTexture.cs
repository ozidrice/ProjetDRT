using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangementTexture : MonoBehaviour
{

	public static ChangementTextureInterface typeChangementTexture;
    public string textureFolderPath;
    private Material newMat;

	public void setRandom(){
		typeChangementTexture = new ChangementTextureRandom(textureFolderPath);
	}

	public void setTypeChangementTexture(ChangementTextureInterface changeText){
		typeChangementTexture = changeText;

	}

	public void ok(){}


    public void appliquerTexture()
    {
		GameObject go = GameObject.Find ("modele");
		Component[] models = go.gameObject.GetComponentsInChildren<Component>();

		if (go == null) {
			Debug.Log ("model introuvable");
		}
		if(typeChangementTexture == null) 
			typeChangementTexture = new ChangementTextureRandom(textureFolderPath);
        newMat = typeChangementTexture.getMat();
		foreach (Component obj in models)
        {
            try
            {
                obj.GetComponent<MeshRenderer>().material = newMat;
            }
            catch (MissingComponentException)
            { }
        }
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
				typeChangementTexture = new ChangementTextureRandom(textureFolderPath);
				obj.GetComponent<MeshRenderer>().material = typeChangementTexture.getMat();
			}
			catch (MissingComponentException)
			{ }
		}
	}
}
