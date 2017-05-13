using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {open, car, car_pulling_over1, car_pulling_over2, car_escaping, crash, jail}
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.open;
	}//end Start()
	
	// Update is called once per frame
	void Update () {
		if (myState == States.open) 					{open();} 
		else if (myState == States.car) 				{car();} 
		else if (myState == States.car_pulling_over1) 	{car_pulling_over1();} 
		else if (myState == States.car_escaping)		{car_escaping();}
		else if (myState == States.car_pulling_over2)	{car_pulling_over2();}
		else if (myState == States.crash)				{crash();}
	}//end Update
	
	#region State handler methods
	void open (){
		text.text = "\n\nWelcome to Text101! \n\n\nPress Enter to Start your adventure.";
		if (Input.GetKeyDown (KeyCode.Return)) {
			myState = States.car;
		}
	}//end open
	
	void car () {
		text.text = "It was a warm summer's evening, a perfect night for a drive. \n\n" + 
			"\"What could possibly go wrong?\" " +
				"you thought as you were driving down the highway. You had a cool beer in your " +
				"hand and a clear road in front of you. \n\nYou thought you were completely in " + 
				"the clear until the familiar wail of a police sirun and the flashing red and " +
				"blue lights pulled up behind you." +
				"\n\n Press P to Pull over, Press E to try to Escape.";
				
		if (Input.GetKeyDown (KeyCode.P)) 			{myState = States.car_pulling_over1;}
		else if (Input.GetKeyDown(KeyCode.E)) 		{myState = States.car_escaping;}
	}//end car
	
	void car_pulling_over1 () {
		text.text = "You pull your car to the side of the road and the officer pulls up " + 
			"behind you and knocks on your window. \n\nAfter some tests, he takes you to " +
			"jail for drunk driving. \n\nPress enter to return to the beginning";
			
		if (Input.GetKeyDown (KeyCode.Return)) 		{myState = States.open;}
	}//end car_pulling_over
	
	void car_escaping () {
		text.text = "You put your foot to the floor flying around back country roads to " +
			"try to escape the police officer. He is in hot pursuit and gaining on you. \n\n" + 
			"You come to the beginning of the windiest road in the county. \n\n" +
			"Press P to pull over, Press E to continue escaping.";
		
		if (Input.GetKeyDown (KeyCode.P)) 			{myState = States.car_pulling_over2;}
		else if (Input.GetKeyDown(KeyCode.E)) 		{myState = States.crash;}
	}//end car_escaping
	
	void car_pulling_over2 () {
		text.text = "You pull your car to the side of the road and the officer pulls up " + 
			"behind you and knocks on your window. \n\nAfter some tests, he takes you to " +
			"jail for drunk driving and not stopping. \n\nPress enter to return to the beginning.";
		
		if (Input.GetKeyDown (KeyCode.Return)) 		{myState = States.open;}
	}//end car_pulling_over
	
	void crash () { 
		text.text = "You do not make the first turn fast enough and crash your car. You are in a " +
			"dazed state and do not know what is going on. \n\nAfter a short stay in the hospital " +
			"the judge orders you to several years in jail for dangerous driving, drunk driving, " +
				"and not stopping. \n\nPress enter to return to the beginning.";
		
		if (Input.GetKeyDown (KeyCode.Return)) 		{myState = States.open;}
	}//end crash
	#endregion State handler methods
	
}//end TextController : MonoBehaviour
