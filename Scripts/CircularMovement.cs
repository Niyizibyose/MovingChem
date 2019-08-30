using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour {
	public float speed=1;
	public float ciraCum=2;
	public float count = 0;
	public  float x;
	public float y;
	public int id;
	void Update(){
		count += Time.deltaTime * speed;
		  x = Mathf.Cos (count) * ciraCum;
		 y = Mathf.Sin (count) * ciraCum;
		Vector3 TargetPosition = new Vector3 (x+2,y,0);
		transform.position = TargetPosition;
	}

}
