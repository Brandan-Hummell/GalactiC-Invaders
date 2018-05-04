using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDefeat : MonoBehaviour {
    
	private Transform playerShield;

	void Start () {
		playerShield = GetComponent<Transform> ();
	}
	
	void Update () {
		if (playerShield.childCount == 0) {
			PlayerLifeSystem.playerLives = 0;
			GameOver.isPlayerDead = true;
		}
	}
}
