using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find ("Nedra");
		MeshFilter[] meshs = go.GetComponentsInChildren<MeshFilter>();

		Proba p1 = new ProbaExponentielle (meshs [0].mesh.vertices [0]);
		Proba p2 = new ProbaNormale (meshs [0].mesh.vertices [50000]);
		Vector3 v1 = p1.transformPoint ();
		Vector3 v2 = p2.transformPoint ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
