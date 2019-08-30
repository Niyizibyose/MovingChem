using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCtrl : MonoBehaviour {
	public GameObject panel,panelPackage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void levelChanger(){
		panel.gameObject.SetActive (false);
		panelPackage.SetActive (true);
	}
}
