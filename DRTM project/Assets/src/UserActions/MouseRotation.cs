using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour {
   public float speed;
    
    private Vector3 vOriginMouse;
    private bool dragging;

    void start()
    {
		if (speed == 0 || speed == null)
            speed = 100;
		
    }


    void Update()
    {
		Vector3 center = new Vector3 (0,0,0);
		if (this.GetComponentsInChildren<MeshRenderer>().Length > 0)
			center = this.GetComponentsInChildren<MeshRenderer>()[0].transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            dragging = true;
            vOriginMouse = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0)){
            dragging = false;
        }
        if (dragging)
        {
            //Debug.Log("dragging...");
            Vector3 vRot = new Vector3(/*-(vOriginMouse.y - Input.mousePosition.y)*/0, vOriginMouse.x - Input.mousePosition.x, 0);
            transform.RotateAround(center,vRot, speed*Time.deltaTime);           
            vOriginMouse = Input.mousePosition;
        }
        /*else
        {
           Debug.Log("Not dragging.");
        }*/
    }

}
