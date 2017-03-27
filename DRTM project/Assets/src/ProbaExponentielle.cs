using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProbaExponentielle : Proba {
	
	private System.Random r;

	public ProbaExponentielle(Vector3 p) : base(p){
		r = new System.Random (1);
	}

	public override Vector3 transformPoint() {
		float lambda = 1.0f;
		float resultX = this.point.x;
		float resultY = this.point.y;
		float resultZ = this.point.z;

		float maxValueX = this.point.x * 2;
		float minValueX = this.point.x / 2;
		float maxValueY = this.point.y * 2;
		float minValueY = this.point.y / 2;
		float maxValueZ = this.point.z * 2;
		float minValueZ = this.point.z / 2;

		float u = (float)r.NextDouble();
		float t = (float)-Math.Log(u) / lambda;
		float incrementX = (maxValueX - minValueX) / 6.0f;
		float incrementY = (maxValueY - minValueY) / 6.0f;
		float incrementZ = (maxValueZ - minValueZ) / 6.0f;

		resultX = minValueX + (t * incrementX);
		resultY = minValueY + (t * incrementY);
		resultZ = minValueZ + (t * incrementZ);

		Debug.Log ("PROBA EXPONENTIELLE : X = " + resultX + ", Y = " + resultY + ", Z = " + resultZ);
		return new Vector3(resultX, resultY, resultZ);
	}
}