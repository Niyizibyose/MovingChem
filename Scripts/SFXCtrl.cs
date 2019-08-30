using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCtrl : MonoBehaviour {
	public SFX sfx;
	public static  SFXCtrl instance;


	void Awake(){
		if (instance == null) {
			instance = this;
		}

	}



	public void AnswerSfx(Vector3 pos){

		Instantiate (sfx.answer, pos, Quaternion.identity);
	}
	public void LevelCompleteSfx(Vector3 pos){

		Instantiate (sfx.levelComplete, pos, Quaternion.identity);
	}

}
