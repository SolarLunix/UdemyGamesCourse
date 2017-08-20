using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {
    private int max = 1000;
    private int min = 0;
    private int guess = 500;
    private string instructions = "Up arrow for higher, Down arrow for lower, \nor Enter if I got it right!";

	// Use this for initialization
	void Start () {
        StartGame();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            NextGuess();
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            print("I win!");
            print("~.:*:.~");
            StartGame();
        }
	}

    void NextGuess()
    {
        System.Random rnd = new System.Random();
        int last = guess;
        while (guess == last)
        {
            guess = rnd.Next(min, max);
            if(max-min < 2)
            {
                guess = max;
            }
        }

        if (min < max && guess < 1001)
        {
            print("(" + min + "," + max + ") Is your number " + guess + "?");
            print(instructions);

            int test = max - 1; 
            if(min >= test)
            {
                min = min + 1;
                print(min + "new min");
            }
        }
        else
        {
            print("I suspect a cheater! Min: " + min + " Max: " + max);
            print("~.:*:.~");
            StartGame();
        }
    }  

    void StartGame()
    {
        max = 1000;
        min = 0;
        guess = -1;

        string intro = "Welcome to Number Wizard!";
        intro += "\nPlease pick a number in your head but don't tell me.";
        print(intro);
        intro = "The lowest your number can be is: " + min;
        intro += "\nThe highest your number can be is:" + max;
        print(intro);

        NextGuess();
        max++;
    }
}
