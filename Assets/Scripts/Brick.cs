using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

//	private AudioSource brickDestroedSound;

	private void Awake () {
//		brickDestroedSound = GetComponent<AudioSource> ();
	}

	private void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag.Equals ("Ball")) {
//			brickDestroedSound.Play ();
			Destroy (gameObject);
		}
	}
}
