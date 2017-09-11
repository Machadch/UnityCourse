using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	private int timesHit;
	private LevelManager levelManager;
	private Powerups powerups;
	private bool isBreakable;
	private bool isPowerup;
	public Sprite[] hitSprites;
	public static int BricksInLevel;
	public string powerupValue;
	private Ball ball;
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		isBreakable = (this.tag == "Breakable");
		isPowerup = (this.tag == "Powerup");
		if (isBreakable || isPowerup) {
			BricksInLevel++;
			print (BricksInLevel);
		}
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		if (isBreakable || isPowerup) {
			HandleHit();
			}
	}
	
	void HandleHit() {
		int maxHits = hitSprites.Length + 1;
		this.timesHit += ball.hitPower;
		if (timesHit >= maxHits) {
			if(this.isPowerup){
				Powerups.SpawnPowerup(powerupValue);
			}
			Destroy(gameObject);
			BricksInLevel -= 1;
			levelManager.BrickDestroyed();
		} else {
			LoadSprites();
		}
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
}
