using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class CheckerCtrl : MonoBehaviour {
	public static CheckerCtrl instance;
	public GameObject []elements;
	public GameObject[] electrons;
	public int index;
	public int fourShell,threeShell,twoShell,oneShell;
	public bool isRight;
	public Sprite redElectron;


	void Awake(){
		if(instance==null){
			instance = this;
		}
	}

	// Use this for initialization
	void Start(){
		QuestionGenerator ();
	}
	public void OnBtnClick(){
		
		CheckAnswer ();


	}
	public void QuestionGenerator(){
		if (index < elements.Length) {
			elements [index].SetActive (true);
			electrons [index].SetActive (true);
		}
	}
	public void DeactiveQustion(){
		if (index < elements.Length) {
			elements [index].SetActive (false);
			electrons [index].SetActive (false);

		}
	}
	public void UpDateOptions(){
		if (index < elements.Length) 
		index++;
	}

	public void CheckAnswer(){
		if (oneShell <= 2 && twoShell <= 8 && threeShell <= 18 && fourShell <= 32) {
			//int sum = oneShell + twoShell + threeShell + fourShell;
			CheckElectrons ();
			if (isRight) {
				DeactiveQustion ();
				GameCtrl2.instance.UpdateScore ();
				AudioCtrl.instance.CorrectAns (Camera.main.transform.position);
				UpDateOptions ();
				Reset ();

			} else {
				
				AudioCtrl.instance.IncorrectAns (Camera.main.transform.position);
				GameObject[] x = GameObject.FindGameObjectsWithTag ("BlueElectron");
				for (int i = 0; i < x.Length; i++) {
					x [i].gameObject.GetComponent<SpriteRenderer> ().sprite = redElectron;
				}
				Invoke ("ResetFalseAnswer", 1.5f);

			}
		} else {
			AudioCtrl.instance.IncorrectAns (Camera.main.transform.position);
			GameObject[] x = GameObject.FindGameObjectsWithTag ("BlueElectron");
			for (int i = 0; i < x.Length; i++) {
				x [i].gameObject.GetComponent<SpriteRenderer> ().sprite = redElectron;
			}
			Invoke ("ResetFalseAnswer", 1.5f);

		}
	}
	public void ResetFalseAnswer(){
		oneShell = 0;
		twoShell = 0;
		threeShell = 0;
		fourShell = 0;
		isRight = false;
		GameObject []x=GameObject.FindGameObjectsWithTag ("BlueElectron");
		for (int i = 0; i < x.Length; i++) {
			Destroy (x [i].gameObject);
		}
	}
	public void Reset(){
		oneShell = 0;
		twoShell = 0;
		threeShell = 0;
		fourShell = 0;
		isRight = false;
		GameObject []x=GameObject.FindGameObjectsWithTag ("BlueElectron");
		for (int i = 0; i < x.Length; i++) {
			Destroy (x [i].gameObject);
		}
		QuestionGenerator ();

	}
	public void CheckElectrons(){
		switch(index){
		case 0:
			if (oneShell == 2 && twoShell == 0 && threeShell == 0 && fourShell == 0) {
				isRight = true;
			} else {
				isRight = false;
			}
			break;
		case 1:
			if (oneShell == 2 && twoShell == 3 && threeShell == 0 && fourShell == 0) {
				isRight = true;
			} else {
				isRight = false;
			}
			break;
		case 2:
			if (oneShell == 2 && twoShell == 8 && threeShell == 2 && fourShell == 0) {
				isRight = true;
			} else {
				isRight = false;
			}
			break;
		case 3:
			if (oneShell == 2 && twoShell == 8 && threeShell == 1 && fourShell == 0) {
				isRight = true;
			} else {
				isRight = false;
			}
			break;
		case 4:
			if (oneShell == 2 && twoShell == 8 && threeShell == 3 && fourShell == 0) {
				isRight = true;
			} else {
				isRight = false;
			}
			break;
		case 5:
			if (oneShell == 2 && twoShell == 6 && threeShell == 0 && fourShell == 0) {
				isRight = true;
			} else {
				isRight = false;
			}
			break;
		case 6:
			if (oneShell == 1 && twoShell == 0 && threeShell == 0 && fourShell == 0) {
				isRight = true;
			} else {
				isRight = false;
			}
			break;
		case 7:
			if (oneShell == 2 && twoShell == 8 && threeShell == 5 && fourShell == 0) {
				isRight = true;
			} else {
				isRight = false;
			}
			break;
		case 8:
			if (oneShell == 2 && twoShell == 8 && threeShell == 0 && fourShell == 0) {
				isRight = true;
			} else {
				isRight = false;
			}
			break;
		case 9:
			if (oneShell == 2 && twoShell == 2 && threeShell == 0 && fourShell == 0) {
				isRight = true;
			} else {
				isRight = false;
			}
			break;
		}

	}
}
