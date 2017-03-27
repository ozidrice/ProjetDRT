using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgrandissementRandom : DeformationAbstract{
	
	override public void deformer(){
		GameObject go = GameObject.Find ("modele");
		MeshFilter[] childs = go.GetComponentsInChildren<MeshFilter>(false);
		foreach (MeshFilter mf in childs) {
			Mesh mesh = mf.mesh;
			newVertices.AddRange( mesh.vertices );
			Debug.Log(newVertices.Count);
			for(int i = 0; i<newVertices.Count; i++){
				if(i%1 == 0){
					//for (int j = i; j < i + 20; j++) {
					newVertices [i] *= 1.5f * Mathf.Cos(Random.value);
					//}

				}
			}
			mesh.vertices = newVertices.ToArray();
			newVertices = new List<Vector3>();

		}
	}

	override public string toString(){
		return "AgrandissementRandom";
	}
}
