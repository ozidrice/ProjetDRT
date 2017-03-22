using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChangementTextureSelectionne : ChangementTextureInterface {

	string pathMat;

	public ChangementTextureSelectionne(string path){
		pathMat = path;
	}



	public void selectionner(string pathToMaterial){
		pathMat = pathToMaterial;
	}

	public Material getMat(){
		return (Material)AssetDatabase.LoadAssetAtPath(pathMat, typeof(Material));
	}

}
