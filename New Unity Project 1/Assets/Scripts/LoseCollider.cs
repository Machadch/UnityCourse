using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private LevelManager LevelManager;
	
	void Start () {
		LevelManager = GameObject.FindObjectOfType<LevelManager>();
		}
	
	void OnTriggerEnter2D (Collider2D trigger) {
		Brick.BricksInLevel = 0;
		LevelManager.LoadLevel("Lose Screen"); 
	}
	void OnCollisionEnter2D (Collision2D collision) {
		print ("Collider");
	}
}
