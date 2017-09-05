using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	public Sprite[] hitSprites;
	public static int BricksInLevel;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
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
		if (isBreakable) {
			HandleHit();
		}
	}
	
	void HandleHit() {
		int maxHits = hitSprites.Length + 1;
		this.timesHit += 1;
		if (timesHit >= maxHits) {
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
