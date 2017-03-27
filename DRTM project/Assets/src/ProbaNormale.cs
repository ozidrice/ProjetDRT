using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProbaNormale : Proba{


	public ProbaNormale (Vector3 p) : base (p){}

	public override Vector3 transformPoint () {
		float x = (float)((1 / Math.Sqrt (2*Math.PI)) * Math.Exp ((-1 / 2) * (this.point.z * this.point.z)));
		float y = (float)((1 / Math.Sqrt (2*Math.PI)) * Math.Exp ((-1 / 2) * (this.point.z * this.point.z)));
		float z = (float)((1 / Math.Sqrt (2*Math.PI)) * Math.Exp ((-1 / 2) * (this.point.z * this.point.z)));

		Debug.Log ("PROBA NORMALE : X = " + x + ", Y = " + y + ", Z = " + z);
		return new Vector3 (x, y, z);
	}
}

