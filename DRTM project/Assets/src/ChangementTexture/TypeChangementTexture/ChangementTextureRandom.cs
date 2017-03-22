using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChangementTextureRandom : ChangementTextureInterface {
	string pathToMaterials;

	public ChangementTextureRandom(string pathToMaterials){
		this.pathToMaterials = pathToMaterials;
	}

    public Material getMat()
    {
		FileTree mainTree = new FileTree (pathToMaterials.TrimStart(pathToMaterials.ToCharArray()), pathToMaterials);
		List<string> listTexturePath = mainTree.getPaths();
		for(int i = 0; i<listTexturePath.Count; i++) {
			if (!listTexturePath[i].EndsWith (".mat")) {
				listTexturePath.RemoveAt(i);
				i--;
			}
		}
        int randomInt = Mathf.RoundToInt((listTexturePath.Count - 1) * UnityEngine.Random.value);
        return (Material)AssetDatabase.LoadAssetAtPath(listTexturePath[randomInt], typeof(Material));
   }

}
