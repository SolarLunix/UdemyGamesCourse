using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	private bool autoPlay;
	private Ball ball;

	// Use this for initialization
	void Start () {
		autoPlay = false;
		ball = GameObject.FindObjectOfType<Ball>();
	}//end Start

	// Update is called once per frame
	void Update () {
		if (!autoPlay){
			MoveWithMouse();
		}else{
			AutoPlay();
		}

		if (Input.GetKeyDown("a")){
			autoPlay = !autoPlay;
		}
	}//end Update

	void MoveWithMouse(){
		//Get the position of the mouse but don't let it leave the screen
		float mousePosInBlocks = Mathf.Clamp((Input.mousePosition.x / Screen.width * 16), 1f, 15f);

		//Create a Vector3 with the mousemoving as the x, and make sure the y and z stay the same
		Vector3 paddlePos = new Vector3(mousePosInBlocks, this.transform.position.y, 0f);

		//move the paddle
		this.transform.position = paddlePos;
	}//end MoveWithMouse

	void AutoPlay(){
		float ballpos = Mathf.Clamp(ball.transform.position.x, 1f, 15f);
		Vector3 paddlePos = new Vector3(ballpos, this.transform.position.y, 0f);

		//move the paddle
		this.transform.position = paddlePos;
	}//end AutoPlay
}
