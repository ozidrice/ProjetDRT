using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgrandissementLisse : DeformationAbstract{
	private static int i;

	override public void deformer(){
		GameObject go = GameObject.Find ("modele");
		MeshFilter[] childs = go.GetComponentsInChildren<MeshFilter>(false);
		MeshFilter child = childs[Mathf.RoundToInt (Random.value * (childs.Length-1))];
		Vector3 vRef = child.mesh.vertices[Mathf.RoundToInt(Random.value*child.mesh.vertices.Length-1)];


		foreach (MeshFilter mf in childs) {
			Mesh mesh = mf.mesh;
			newVertices.AddRange( mesh.vertices );
			for(int i = 0; i<newVertices.Count; i++){
				float marge = 0.055f;
				if(estAProximité(marge, vRef,newVertices[i])){
					newVertices [i] = calculerVecteur(vRef,marge,1.4f,newVertices[i]);
				}
			}
			mesh.vertices = newVertices.ToArray();
			newVertices = new List<Vector3>();
		}
	}
	// 1.4*((0.055-0.044)/0.055)
	static Vector3 calculerVecteur(Vector3 center, float rayon, float hauteurEnSonCentre, Vector3 vecteurCible){
		float distanceDuCentre = Vector3.Distance (center, vecteurCible);
		float hauteur = 1+hauteurEnSonCentre*((rayon-distanceDuCentre)/rayon); 

		i++;
		if (i%2000==0) {
			Debug.Log (distanceDuCentre);
			i = 0;
		}
		return vecteurCible * hauteur;
	}
	static bool estAProximité(float marge, Vector3 v1, Vector3 v2){
		if(Vector3.Distance (v1, v2) < marge){
			return true;
		}
		return false;
	}

	override public string toString(){
		return "Eclats";
	}

}

