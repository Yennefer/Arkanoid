using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float bounceForce = 200F;

	private Rigidbody2D rb2d;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		Vector2 movement = new Vector2(bounceForce, bounceForce);
		rb2d.AddForce (movement);
	}
}
