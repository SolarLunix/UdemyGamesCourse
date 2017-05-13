using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("Load level requested for: " + name); //Log to the console just in case
		SceneManager.LoadScene(name); //move to the next level
	}//end LoadLevel

	void Awake (){
		DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Guess"));
	}

}
