using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int numBricks = 0;
	public GameObject smokeObj;

	private int timesHit;
	private bool isBreakable;
	private LevelManager lm;

	// Use this for initialization
	void Start () {
		lm = GameObject.FindObjectOfType<LevelManager>();
		isBreakable = (this.tag == "Breakable");
		if(isBreakable)		{numBricks++;} //only increase if its a breakable block
		timesHit = 0;
	}//end Start

	void HandleHits(){
		timesHit++;

		int maxHits = hitSprites.Length + 1;

		if (timesHit >= maxHits) {
			DestroyBrick();
		} else {
			LoadSprites();
		}
	}

	void DestroyBrick(){
		numBricks--; //remove a brick
		lm.BrickDestroyed();
		GameObject smoke = Instantiate(smokeObj, gameObject.transform.position, Quaternion.identity);
		smoke.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
		Destroy(gameObject);
	}

	void OnCollisionEnter2D (Collision2D hit){
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if(isBreakable){    
			LevelManager.score++;                                                                                                                                                                   
			HandleHits();
		}
	}//end OnCollisionEnter2D

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		//ensure that there is a new sprite to load
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}else{
			Debug.LogError("Missing Sprite");
		}
	}//end LoadSprites

}
