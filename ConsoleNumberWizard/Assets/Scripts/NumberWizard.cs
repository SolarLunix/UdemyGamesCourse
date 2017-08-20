using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {
    private int max = 1000;
    private int min = 0;
    private int last = -1;
    private int guess = 500;
    private string instructions = "Up arrow for higher, Down arrow for lower, \nor Enter if I got it right!";

	// Use this for initialization
	void Start () {
        string intro = "Welcome to Number Wizard!";
        intro += "\nPlease pick a number in your head but don't tell me.";
        print(intro);
        intro = "The lowest your number can be is: " + min;
        intro += "\nThe highest your number can be is:" + max;
        print(intro);

        print("Is your number " + guess + "?");
        print(instructions);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("up"))
        {
            action("up");
        }
        else if (Input.GetKeyDown("down"))
        {
            action("down");
        }
	}

    void action(string button)
    {
        print("The " + button + " was pressed.");
    }
}
