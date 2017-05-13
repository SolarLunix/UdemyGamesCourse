using UnityEngine;
using System.Collections;

public class NumberWizzard : MonoBehaviour {
	int count;
	int max;
	int min;
	int guess;

	// Use this for initialization
	void Start () {
		StartGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			min = guess;
			UpdateGuess();
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			max = guess;
			UpdateGuess();
		} else if (Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Return)){
			print ("I won in " + count + " moves!");
			print ("-----------------------------");
			StartGame ();
		}
	}
	
	void UpdateGuess () {
		System.Random rnd = new System.Random();
		count++;
		guess = rnd.Next(min, max);
		print ("Is your number higher or lower than " + guess + "?");
		print ("up arrow = higher, down arrow = lower, enter/return = correct");
	}
	
	void StartGame () {
		print ("Welcome to Number Wizzard (A Number Wang spin off)");
		print ("Pick a number in your head, but don't tell me.");
		
		max = 1000;
		guess = 500;
		min = 0;
		count = 0;
		
		print ("Your number must be between " + min + " and " + max + ".");
		
		UpdateGuess();
		max++;
	}
}
