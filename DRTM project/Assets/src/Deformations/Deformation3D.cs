using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deformation3D : MonoBehaviour {

	List<Vector3> newVertices=new List<Vector3>();
	Vector2[] newUV;
	int[] newTriangles;


	public void deformer() {
		/*
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		newVertices = mesh.vertices;

		Debug.Log(newVertices.Length);
		for(int i = 0; i<newVertices.Length; i++){
			if(i%100 == 0){
				for (int j = i; j < i + 20; j++) {
					newVertices [j] *= 2.2f;
				}
			}
		}
		//mesh.Clear();


		// Do some calculations...
		mesh.vertices = newVertices;
		//mesh.uv = newUV;
		//mesh.triangles = newTriangles;
		*/

		/*_________________________________________*/
		/*GameObject go = GameObject.Find ("modele");
		MeshFilter[] childs = go.GetComponentsInChildren<MeshFilter>(false);
		foreach (MeshFilter mf in childs) {
			Mesh mesh = mf.mesh;
			newVertices = mesh.vertices;
			Debug.Log(newVertices.Length);
			for(int i = 0; i<newVertices.Length; i++){
				if(i%1 == 0){
					//for (int j = i; j < i + 20; j++) {
					newVertices [i] *= 1.5f * Mathf.Cos(Random.value);
					//}
				}
			}
			mesh.vertices = newVertices;*/

		GameObject go = GameObject.Find ("modele");
		MeshFilter[] childs = go.GetComponentsInChildren<MeshFilter>(false);

		foreach (MeshFilter mf in childs) {

			Mesh mesh = mf.mesh;
			newVertices.AddRange(mesh.vertices);
			Debug.Log(newVertices.Count);
			newVertices.Sort ((Vector3 x, Vector3 y) => x.x.CompareTo(y.x));
			childs[0].mesh.vertices = newVertices.GetRange(0,newVertices.Count/2).ToArray();
		}

	}
		

}
