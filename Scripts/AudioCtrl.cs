using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCtrl : MonoBehaviour {

	public static AudioCtrl instance;
	public GameAudio gameAudio;
	[Tooltip("Use to on/off the audio of game from inspector")]
	public bool soundOn;
	public GameObject bgMusic;
	public bool bgMusicOn;


	// Use this for initialization
	void Start () {

		if(instance==null){
			instance = this;
		}
		if(bgMusicOn){
			bgMusic.gameObject.SetActive (true);
		}

	}

	public void CorrectAns(Vector3 playerPos){
		if(soundOn){
			AudioSource.PlayClipAtPoint (gameAudio.correctAns,playerPos);
		}
	}
	public void LevelComplete(Vector3 playerPos){
		if(soundOn){
			AudioSource.PlayClipAtPoint (gameAudio.levelComplete,playerPos);
		}
	}
	public void WritingQuestion(Vector3 playerPos){
		if(soundOn){
			AudioSource.PlayClipAtPoint (gameAudio.writingQuestion,playerPos);
		}
	}
	public void IncorrectAns(Vector3 playerPos){
		if(soundOn){
			AudioSource.PlayClipAtPoint (gameAudio.inCorrectAns,playerPos);
		}
	}

}
