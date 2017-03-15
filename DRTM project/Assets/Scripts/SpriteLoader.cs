using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
﻿using System;
public class SpriteLoader : MonoBehaviour {


	private string path="";

	// Use this for initialization
	void Start () {
		loadSprite();
		Debug.Log("Sprite is loading");
				
	}
	

	void loadSprite(){
		string directory = Application.dataPath + "/screenshots";
		int nbFiles=DirCount(directory)-1;
		Debug.Log(nbFiles);
		path= directory + "/screen_1920x1080_"+ nbFiles +".jpg";
		Debug.Log(path);
	}

	int DirCount(string path){

        
         // Add file sizes.

	 int i = 0;
         foreach (string file in System.IO.Directory.GetFiles(path)){
         	if (file.EndsWith(".jpg")){
			i++;
		}	  

         }
         return i;
     }

}
