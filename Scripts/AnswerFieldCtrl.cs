using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerFieldCtrl : MonoBehaviour {
	public Transform[] pos;
	public GameObject popUpScore;
	public GameObject popUpScore2;
	public Transform popUpScoreSpawner;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other){
		GameCtrl.instance.DeactiveOption ();
		SFXCtrl.instance.AnswerSfx (other.transform.position);
		if(other.gameObject.CompareTag("Correct")){
			Instantiate (popUpScore,popUpScoreSpawner.position,Quaternion.identity);
			AudioCtrl.instance.CorrectAns (other.gameObject.transform.position);
			GameCtrl.instance.UpdateScoreCount();
			GameCtrl.instance.UpdateCorrectCount ();
			Invoke ("GenerateNextQ",3f);

		}else if(other.gameObject.CompareTag("Incorrect")){
			GameCtrl.instance.UpdateIncorrectCount ();
			AudioCtrl.instance.IncorrectAns (other.gameObject.transform.position);
			Instantiate (popUpScore2,popUpScoreSpawner.position,Quaternion.identity);
			switch(other.gameObject.GetComponent<CircularMovement>().id){
			case 1:
				other.gameObject.transform.position = pos [0].position;
				break;
			case 2:
				other.gameObject.transform.position = pos [1].position;
				break;
			case 3:
				other.gameObject.transform.position = pos [2].position;
				break;

			case 4:
				other.gameObject.transform.position = pos [3].position;
				break;


			case 5:
				other.gameObject.transform.position = pos [4].position;
				break;

			case 6:
				other.gameObject.transform.position = pos [5].position;
				break;

			default:
				break;}
			Invoke ("GenerateNextQ",3f);

		}

		}


	void DestroyOptions(){
		GameCtrl.instance.DeactiveOption ();
	}
	void GenerateNextQ(){
		GameCtrl.instance.GenerateNextQuestion();
	}
	void ActivateOptions(){
		GameCtrl.instance.ActiveOption ();
	}
}
