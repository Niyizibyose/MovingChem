using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {
	public bool dragging = false;
	public bool collision=false;
	Vector3 position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BeginDrag(){
		position = gameObject.transform.position;
		dragging = true;
	}

	public void Drag(){
		transform.position = Input.mousePosition;
		
	}

	public void Drop(){

		if(!collision){
			gameObject.transform.position = position;
		}
		dragging = false;





	}
}
