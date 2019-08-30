using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerCtrl : MonoBehaviour {
	Image healthbar;
	float maxHealth = 200f;
	public float health;
	// Use this for initialization
	void Start () {
		healthbar = GetComponent<Image> ();
		health = maxHealth;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			GameCtrl2.instance.isGameOver = true;
		}
		if(CheckerCtrl.instance.index>9 && health>0){
			GameCtrl2.instance.LevelComplete ();
		}

			health -= (float)Time.deltaTime + 0.01f;
			healthbar.fillAmount = health / maxHealth;


	}
}
