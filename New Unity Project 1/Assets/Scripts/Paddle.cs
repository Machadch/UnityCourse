using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	float maxSpeed = 10;
	
	// Use this for initialization
	void Start () {
		Vector3 paddlePos = new Vector3 (0.5f,this.transform.position.y, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		//Mouse Controlls
		Vector3 paddlePos = new Vector3 (0.5f,this.transform.position.y, 0f);
		float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);
		paddlePos.x = Mathf.Clamp(mousePosInBlocks,0.5f,15.5f);
		
		//Controller Controls
		//Vector3 paddlePos = new Vector3 (this.transform.position.x,this.transform.position.y, 0f);
		//float controllerInput = (Input.GetAxis("Horizontal"));
		//paddlePos.x = Mathf.Clamp(paddlePos.x + (controllerInput / 2),0.5f,15.5f);
		
		
		
		this.transform.position = paddlePos;
		
		
	}
}
