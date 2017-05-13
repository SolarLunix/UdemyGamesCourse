using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	static public int lives = 5;
	static public int score = 0;
	public Text livesTxt;
	public Text scoreTxt;

	void Start() {
		if (livesTxt != null){
			livesTxt.text = "LIVES: " + lives;
		}
		if (scoreTxt != null){
			scoreTxt.text = score + "";
		}
	}//end Start

	void Update() {
		if (scoreTxt != null){
			scoreTxt.text = score + "";
		}
	}//end Update

	public void LoadLevel(string name) {
		if (name == "Lose"){
			if (lives < 0) {
				Brick.numBricks = 0;
				lives = 5;
				SceneManager.LoadScene(name); //move to the lose level
			} else {
				livesTxt.text = "LIVES: " + lives;
				Ball.Reset();
			}
		} else if (name == "Title"){
			score = 0; //reset score
			SceneManager.LoadScene(name); //move to the proper level
		}else{
			Brick.numBricks = 0; //reset bricks
			SceneManager.LoadScene(name); //move to the proper level
		}
	}//end LoadLevel

	public void LoadNextLevel() {
		Brick.numBricks = 0;
		int nextLevelNum = SceneManager.GetActiveScene().buildIndex + 1;
		SceneManager.LoadScene(nextLevelNum);
	}//end LoadNextLevel

	public void BrickDestroyed(){
		if(Brick.numBricks <= 0){
			LoadNextLevel();
		}
	}//end BrickDestroyed
}
