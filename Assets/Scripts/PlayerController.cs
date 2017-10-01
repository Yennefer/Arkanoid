using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public float speed = 60F;

	private Rigidbody2D rb2d;

	private void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	private void FixedUpdate () {
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		Vector2 movement = new Vector2 (moveHorizontal, 0);
		rb2d.AddForce (movement * speed);
	}
}
