using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangementTexture : MonoBehaviour
{
	public static ChangementTextureInterface typeChangementTexture;
    public string textureFolderPath;
    private Material newMat;

    void Start()
    {
    }

	public void setRandom() {
		typeChangementTexture = new ChangementTextureRandom ();
	}




    public void appliquerTexture()
    {
		GameObject go = GameObject.Find ("modele");
		Component[] models = go.gameObject.GetComponentsInChildren<Component>();

		if (go == null) {
			Debug.Log ("model introuvable");
		}
		if(typeChangementTexture == null) 
        	typeChangementTexture = new ChangementTextureRandom();
        newMat = typeChangementTexture.getMat(textureFolderPath);
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
}
