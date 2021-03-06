﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
	paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print(paddleToBallVector.y);
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
		//Lock the ball to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown(0)) {
			//Launch the Ball
				print("Clicked");
				this.rigidbody2D.velocity = new Vector2 (4f, 10f);
				hasStarted = true;
				print(rigidbody2D.velocity);
			}
		}
	}
	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 hitRandom = new Vector2 (Random.Range(0f,1f), (Random.Range(0f,1f)));
		if (hasStarted && collision.gameObject.tag != "Breakable") {
			audio.Play ();
		}
		rigidbody2D.velocity += hitRandom; 
	}
}
