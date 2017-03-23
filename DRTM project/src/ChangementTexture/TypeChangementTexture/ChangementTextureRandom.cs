using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChangementTextureRandom : ChangementTextureInterface {

	public Material getMat(string pathToMaterials)
	{
		List<string> listTexturePath = new List<string>();
		foreach (string file in System.IO.Directory.GetFiles(pathToMaterials))
		{
			if (file.EndsWith(".mat"))
			{
				listTexturePath.Add(file);
				Debug.Log("Texture trouvée:" + file);
			}
		}
		int randomInt = Mathf.RoundToInt((listTexturePath.Count - 1) * UnityEngine.Random.value);
		Debug.Log(listTexturePath.Count + " rand:" + randomInt);

		return (Material)AssetDatabase.LoadAssetAtPath(listTexturePath[randomInt], typeof(Material));
	}
}
