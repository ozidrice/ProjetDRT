using UnityEngine;
using System.Collections;
using System.IO;
﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine.UI;


 public class ScreenCapture : MonoBehaviour {

	 // 4k = 3840 x 2160   1080p = 1920 x 1080
	public int captureWidth = 1920;
	public int captureHeight = 1080;

	// optional game object to hide during screenshots (usually your scene canvas hud)
     	public GameObject hideGameObject; 

 	// configure with raw, jpg, png, or ppm (simple raw format)
   	public enum Format { RAW, JPG, PNG, PPM };
     	public Format format = Format.PPM;

	private Rect rect;
	private RenderTexture renderTexture;
     	private Texture2D screenShot;

	public void Save(){
		var path = EditorUtility.SaveFilePanel(
 				"Save texture as PNG",
 				Application.dataPath + "/screenshots",
 				"screen_1920x1080" + ".png",
 				"png");
	 		var width = 900;
     		var height = 700;
     		var startX = 0;
     		var startY = 0;
     		var tex = new Texture2D(width,height,TextureFormat.RGB24,false);
     
    		tex.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
     		tex.Apply();
     
    		 // Encode texture into PNG
    		var bytes = tex.EncodeToPNG();
     		Destroy(tex);
     
    		File.WriteAllBytes(path, bytes);
     

	}

	
}
