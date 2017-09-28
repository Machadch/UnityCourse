using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	public int hitPower;
	public static Ball Instance;
	private SpriteRenderer spriteRenderer;
	private CircleCollider2D circleCollider;
	private Sprite lastSprite;
	private int FireballOn = 0;
	public GameObject FireballObject;
	
	// Use this for initialization
	void Start () {
	Instance = this;
	paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print(paddleToBallVector.y);
		hitPower = 1;
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
			}

			if (FireballOn == 1) {
				FireballObject.transform.position = this.transform.position;
			}
		}
	}
	
	public void UpdateHitPower (int NewHitValue) {
		this.hitPower = NewHitValue;
		ChangeSize();
			}

	public void ChangeSize () {
		Vector3 scale = new Vector3( 2f, 2f, 1f );
		transform.localScale = scale;
		circleCollider = GetComponent<CircleCollider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		Vector3 spriteHalfSize = spriteRenderer.sprite.bounds.extents;
		circleCollider.radius = spriteHalfSize.x > spriteHalfSize.y ? spriteHalfSize.x : spriteHalfSize.y;
		lastSprite = spriteRenderer.sprite;
	}

	public void spawnFireball(Ball ball) {
		GameObject FireBallObject = (GameObject)Instantiate(FireballObject, ball.transform.position, ball.transform.rotation);
		print("spawned FB");
		FireballOn = 1;
	}
}