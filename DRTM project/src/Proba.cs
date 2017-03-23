using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Proba {

	protected Vector3 point;

	public Proba(Vector3 p) {
		//r = new System.Random(1);
		Debug.Log ("X : " + p.x + ", Y: " + p.y + ", Z : " + p.z);
		this.point = p;
	}

	abstract public Vector3 transformPoint();

}
