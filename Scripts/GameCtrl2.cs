using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl2 : MonoBehaviour {
	public GameObject gameOverPanel;
	public GameObject levelCompletePanel;
	public Text scoreTxt,gameOverScore,levelComScore;
	public static GameCtrl2 instance;
	public int score;
	public bool isGameOver;

	void Awake(){
		if(instance==null){
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isGameOver){
			GameOver ();
		}
	}

	public void UpdateScore(){
		score+=5;
		scoreTxt.text = ": " + score;
	}

	public void GameOver(){
		gameOverScore.text = "" + score;
		gameOverPanel.SetActive (true);
	}
	public void LevelComplete(){
		levelComScore.text = " " + score;
		levelCompletePanel.SetActive (true);

	}


}
