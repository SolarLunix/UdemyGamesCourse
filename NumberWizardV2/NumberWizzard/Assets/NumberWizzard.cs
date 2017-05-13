using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class NumberWizzard : MonoBehaviour {
	int count;
	int max;
	int min;
	int guess;
	public Text titleText;
	public Text guessText;
	public Button higher;
	public Button lower;
	public Button correct;

	void Start () {
		StartGame();
	}

	public void guessHigher () {
		min = guess + 1;
		UpdateGuess();
	}

	public void guessCorrect () {
		higher.enabled = false;
		lower.enabled = false;
		correct.enabled = false;
		lower.GetComponentInChildren<Text>().text = " ";
		higher.GetComponentInChildren<Text>().text = " ";
		correct.GetComponentInChildren<Text>().text = " ";
		titleText.text = "I guessed your number in " + count + " moves, that means:";
		if (count < 20){
			guessText.text = "I won!";
		} else {
			guessText.text = "You won!";
		}
	}

	public void guessLower () {
		max = guess;
		UpdateGuess();
	}
	
	void UpdateGuess () {
		System.Random rnd = new System.Random();
		count++;
		print (count);
		guess = rnd.Next(min, max);
		guessText.text = "" + guess;
	}
	
	public void StartGame () {
		max = 1000000;
		min = 0;
		count = 0;

		UpdateGuess();
		max++;
	}
}
