using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float bounceForce = 400F;

	private Rigidbody2D rb2d;
	private AudioSource bollBounceSound;

	private void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
		bollBounceSound = GetComponent<AudioSource> ();
	}

	private void Start () {
		// Creating random vector for the ball
		float xRangeMin = bounceForce / 4;
		float xRangeMax = bounceForce / 4 * 3;
		float bounceForceX = Random.Range(xRangeMin, bounceForce);
		if (bounceForceX > xRangeMax) {
			bounceForceX = xRangeMin - bounceForceX;
		}
		// Y should always be positive - ball should always fly up
		float bounceForceY = bounceForce - Mathf.Abs(bounceForceX);

		Vector2 movement = new Vector2 (bounceForceX, bounceForceY);
		rb2d.AddForce (movement);
	}

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag.Equals ("Floor")) {
			gameObject.SetActive (false);
		}
	}

	private void OnCollisionEnter2D (Collision2D coll) {
		bollBounceSound.Play ();
	}
}
