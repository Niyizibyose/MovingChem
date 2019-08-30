using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimatedTextCtrl : MonoBehaviour {
	public Text textArea;
	public float speed = 0.1f;
	public string[] sentence;
	int characterIndex=0;
	int sentenceIndex=0;
	public GameObject chalk;
	public GameObject chalk2;

	public Transform chalkStopPos,chalkStartPos;
	public bool stopChalk;

	// Use this for initialization
	void Start () {
		StartCoroutine (DisplayTimer ());
		if(GameCtrl.instance.canRespon){
		chalk=Instantiate (chalk2,chalkStartPos.position,Quaternion.identity);
			AudioCtrl.instance.WritingQuestion (gameObject.transform.position);
		}

	}
	IEnumerator DisplayTimer(){
		if(GameCtrl.instance.canRespon){
		while(1==1){
			yield return new WaitForSeconds (speed);
			if(characterIndex>sentence[sentenceIndex].Length){
				continue;
			}
			textArea.text = sentence [sentenceIndex].Substring (0, characterIndex);
				characterIndex++;
			if (characterIndex == sentence [sentenceIndex].Length) {
				chalk.GetComponent<Animator> ().enabled = false;
				stopChalk = true;
				GameCtrl.can = true;
				GameCtrl.instance.ActiveQandA ();
			
			}}
		}

	}
	// Update is called once per frame
	void Update () {
		if (!GameCtrl.instance.canRespon) {
			Destroy (chalk.gameObject);
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			if (characterIndex > sentence [sentenceIndex].Length) {
				characterIndex = sentence [sentenceIndex].Length;
			
			} else if(sentenceIndex < sentence.Length){
				sentenceIndex++;
				characterIndex = 0;
			}
				

			} 
		if(stopChalk){
			chalk.transform.position = Vector3.Lerp (chalk.transform.position,chalkStopPos.position,1f);
		}
		}
		


	public void NextQuestion(){
		if(sentenceIndex < sentence.Length){
			sentenceIndex++;
			characterIndex = 0;
			if(stopChalk&&GameCtrl.instance.canRespon){
				GameObject x = chalk;

						chalk=Instantiate (chalk2,chalkStartPos.position,Quaternion.identity);
				AudioCtrl.instance.WritingQuestion (gameObject.transform.position);
				Destroy (x.gameObject);
				stopChalk = false;


			}

		}

	}
}
