using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using UnityEngine.UI;

public class SpriteMaker : MonoBehaviour {
	
	
	
	public void CaptureScreenshots(){
		int count=0;
		string path="";

		
		if(path.Equals("")){
			path = EditorUtility.SaveFilePanel("Save_Screenshots_Folder",Application.dataPath,"","");
			Debug.Log(path);
		}


		
		Debug.Log("Taking picture");
		

		Texture2D texture = new Texture2D(Screen.width,Screen.height,TextureFormat.ARGB32,false);
		texture.ReadPixels(new Rect(0,0, Screen.width, Screen.height),0,0);
		texture.Apply();

		byte[] bytes = texture.EncodeToPNG();
		File.WriteAllBytes(path+"screen_"+ count + ".png",bytes);
		count ++;
		DestroyObject(texture);
	
	}
}
