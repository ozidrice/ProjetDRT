using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgrandissementMorceau : DeformationAbstract{
	override public void deformer(){
		GameObject go = GameObject.Find ("modele");
		MeshFilter[] childs = go.GetComponentsInChildren<MeshFilter>(false);
		MeshFilter child = childs[Mathf.RoundToInt (Random.value * childs.Length)];
		Vector3 vRef = child.mesh.vertices[Mathf.RoundToInt(Random.value*child.mesh.vertices.Length)];

		foreach (MeshFilter mf in childs) {
			Mesh mesh = mf.mesh;
			newVertices.AddRange( mesh.vertices );
			for(int i = 0; i<newVertices.Count; i++){
				float marge = 0.032f;
				if(estAProximité(marge, vRef,newVertices[i])){
					newVertices [i] = calculerVecteur(vRef,marge,2f,newVertices[i]);
				}
			}
			mesh.vertices = newVertices.ToArray();
			newVertices = new List<Vector3>();
		}
	}

	static Vector3 calculerVecteur(Vector3 center, float rayon, float hauteurEnSonCentre, Vector3 vecteurCible){
		float distanceDuCentre = Vector3.Distance (center, vecteurCible);
		float hauteur = hauteurEnSonCentre*1+(rayon-distanceDuCentre); 
		return vecteurCible * hauteur;
	}
	static bool estAProximité(float marge, Vector3 v1, Vector3 v2){
		if(v1.x - v2.x < marge && v1.x - v2.x > -marge){
			if(v1.y - v2.y < marge && v1.y - v2.y > -marge){
				if(v1.z - v2.z < marge && v1.z - v2.z > -marge){
					return true;
				}
			}
		}
		return false;
	}

	override public string toString(){
		return "AgrandissementMorceau";
	}
}

