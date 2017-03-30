using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
﻿using System;
public class SpriteLoader : MonoBehaviour {


	
	



   	 public void onClick() {

		 string path = EditorUtility.OpenFilePanel("Select an image","/Assets/Screenshots","png");
		 Application.OpenURL(path);
   	 }
	





	



}
