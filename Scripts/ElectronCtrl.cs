using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronCtrl : MonoBehaviour {
	public GameObject electron;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if(gameObject.CompareTag("FourShell")){
			Instantiate (electron,transform.position,Quaternion.identity);
			CheckerCtrl.instance.fourShell++;
		}
		if(gameObject.CompareTag("ThreeShell")){
			Instantiate (electron,transform.position,Quaternion.identity);
			CheckerCtrl.instance.threeShell++;
		}
		if(gameObject.CompareTag("TwoShell")){
			Instantiate (electron,transform.position,Quaternion.identity);
			CheckerCtrl.instance.twoShell++;
		}
		if(gameObject.CompareTag("OneShell")){
			Instantiate (electron,transform.position,Quaternion.identity);
			CheckerCtrl.instance.oneShell++;
		}
	}


}
