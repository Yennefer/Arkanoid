using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float bounceForce = 100F;

	private Rigidbody2D rb2d;

	private void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	private void Start () {
		Vector2 movement = new Vector2 (bounceForce + 100, bounceForce);
		rb2d.AddForce (movement);
	}

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag.Equals ("Floor")) {
			gameObject.SetActive (false);
		}
	}
}
