using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// make a way to can transmite between Scenes.  
/// </summary>
public class SceneChanger : MonoBehaviour {

	public void LoadScene(string name){
		SceneManager.LoadScene (name);
	}

}
