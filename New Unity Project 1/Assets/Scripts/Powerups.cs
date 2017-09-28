using UnityEngine;
using System.Collections;

public class Powerups : MonoBehaviour {

	public static void SpawnPowerup (string PUtype, Ball ball){
			if (PUtype.Contains("BigBall")) {
			ball.UpdateHitPower(10);
			}
		else if (PUtype.Contains("FireBall")) {
			ball.spawnFireball(ball);
		}
	}
}
