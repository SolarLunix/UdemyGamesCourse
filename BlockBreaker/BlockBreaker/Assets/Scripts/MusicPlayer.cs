using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer musicOn = null;

	void Awake () {

		if (musicOn != null){
			Destroy(gameObject);
		}else{
			musicOn = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}//end Awake

}
