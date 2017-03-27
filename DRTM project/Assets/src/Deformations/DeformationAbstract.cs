using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeformationAbstract : MonoBehaviour {
	protected List<Vector3> newVertices=new List<Vector3>();
	protected Vector2[] newUV;
	protected int[] newTriangles;

	public abstract void deformer();
	public abstract string toString();
}
