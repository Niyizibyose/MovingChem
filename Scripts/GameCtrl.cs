using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameCtrl : MonoBehaviour {
	 public GameObject[] options;
	public Transform pos;
	public Image[] question;
	public static bool can;
	public GameData data;
	public UI ui;
	public static int index;
	public static GameCtrl instance;
	bool TimerOn;
	public bool canRespon,isComplete,chalkRespon;
	float TimeLeft;
	public float MaxTime;
	public string TimerString;
	void Awake(){
		if(instance==null){
			instance = this;
		}

	}
	// Use this for initialization
	void Start () {
		TimeLeft = MaxTime;
		TimerOn = true;
		canRespon = true;

		 	
	}
	
	// Update is called once per frame
	void Update () {
		if(TimeLeft > 0&& TimerOn)
			UpdateTimer ();
		if(index==10){                      
			
			canRespon = false;
			isComplete = true;
		}
		if(!canRespon){
			if(TimeLeft>0 && data.score>25){
				LevelComplete ();
				isComplete = false;
			}
			index = 0;

		}
		if (!canRespon) {
			if (TimeLeft <= 0|| data.score <= 25) {
				GameOver ();

			}
		}
	}
	public void GameOver(){
		TimerOn = false;
		AudioCtrl.instance.bgMusic.SetActive(false);
		ui.gfinalTextScore.text = "" + data.score;
		ui.gfinalTextTimer.text = "" + TimerString;
		ui.gcorrectText.text = "" + data.correct;
		ui.gincorrectText.text = "" + data.incorrect;
		ui.GameOverPanel.SetActive (true);
		AudioCtrl.instance.IncorrectAns (gameObject.transform.position);
	}

	public void LevelComplete(){
		AudioCtrl.instance.bgMusic.SetActive(false);
		ui.finalTextScore.text = "" + data.score;
		ui.finalTextTimer.text = "" + TimerString;
		ui.correctText.text = "" + data.correct;
		ui.incorrectText.text = "" + data.incorrect;
		ui.levelCompletePanel.SetActive (true);
		AudioCtrl.instance.LevelComplete (gameObject.transform.position);
		if (isComplete) {
			SFXCtrl.instance.LevelCompleteSfx (pos.position);
		}

		ChooseCap ();
		TimerOn = false;
	}

	public void ActiveOption(){

		options[index].SetActive(true);


	}
	public void DeactiveOption(){
	    can = false;

		options[index].SetActive(false);

		question[index].gameObject.SetActive (false);


	}

	public void ActiveQandA(){

		if(can){
			question[index].gameObject.SetActive (true);
			Invoke ("ActiveOption",1f);
		}
	}

	public void GenerateNextQuestion(){

		GameObject.FindObjectOfType<AnimatedTextCtrl> ().NextQuestion ();
		index++;

	}

	public void UpdateScoreCount(){

		data.score += 5;
		ui.textScore.text = "Score : " + data.score;
	

	}
	public void UpdateCorrectCount(){

		data.correct += 1;
		ui.correctText.text = " " + data.correct;


	}
	public void UpdateIncorrectCount(){

		data.incorrect += 1;
		ui.incorrectText.text = " " + data.incorrect;


	}

	public void ChooseCap(){
		print ("1");
		if(data.score>=25&& data.score<30){
			print ("2");
			ui.cap.sprite = ui.bronz;
		}else if(data.score>=30 && data.score<40){
			print ("3");
			ui.cap.sprite = ui.silver;
		}else if(data.score>=40 || data.score<=50){
			print ("4");
			ui.cap.sprite = ui.gold;
		}
	}
	void UpdateTimer(){

		TimeLeft -= Time.deltaTime;
		int second = (int)(TimeLeft % 60);
		int minutes = (int)(TimeLeft / 60)%60;
		int hours = (int)(TimeLeft / 3600)%24;
		 TimerString = string.Format("{0:0}:{1:00}:{2:00}",hours,minutes,second);
		ui.textTimer.text = TimerString;

		if(TimeLeft <=0){
			ui.textTimer.text = " Timer : 0";

		}
	}


}
