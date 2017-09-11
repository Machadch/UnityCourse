using UnityEngine;
using System.Collections;

public class Powerups : MonoBehaviour {

	public static void SpawnPowerup (string PUtype){
			if (PUtype.Contains("BigBall")) {
				Ball.Instance.UpdateHitPower(10);
			}
		}
}
