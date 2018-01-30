using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float mvSpeed = 5f;

	float xmin = -5f;
	float xmax = 5f;
	float padding = 1f;

	// Use this for initialization
	void Start () {
		float dis = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dis));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dis));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}

	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;

		//if(Input.GetKey(KeyCode.W))
		//	transform.position += transform.up * mvSpeed * Time.deltaTime;
		//if(Input.GetKey(KeyCode.S))
		//	transform.position -= transform.up * mvSpeed * Time.deltaTime;
		if(Input.GetKey(KeyCode.A))
			transform.position -= transform.right * mvSpeed * Time.deltaTime;
		if(Input.GetKey(KeyCode.D))
			transform.position += transform.right * mvSpeed * Time.deltaTime;

		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}
