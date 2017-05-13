using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private static bool hasStarted;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		hasStarted = false;
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			//Lock ball to paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			//wait for a left mouse click to launch
			if (Input.GetMouseButtonDown(0)) {
				//launch on click
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f); 
				hasStarted = true;
			}//end mouse button
		}//end has not started.
	}//end Update

	void OnCollisionEnter2D (Collision2D ball){
		Vector2 moveTweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

		if(hasStarted){
			this.GetComponent<Rigidbody2D>().velocity += moveTweak;
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
        }
	}//end OnCollissionEnter2D

	static public void Reset() {
		hasStarted = false;
	}
}
