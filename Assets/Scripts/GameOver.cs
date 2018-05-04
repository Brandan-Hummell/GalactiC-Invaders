using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public static bool isPlayerDead = false;
	private Text gameOver;

	private float timeOfDeath;

	public GameObject playerShip;

	public Transform spawnLocation;

	void Start () {
		gameOver = GetComponent<Text>();
		gameOver.enabled = false;
	}
	
	void Update () {
		if (isPlayerDead && PlayerLifeSystem.playerLives == 0) {
			Time.timeScale = 0;
			gameOver.enabled = true;
		} else if (isPlayerDead && Time.timeScale == 1) {
            timeOfDeath = Time.realtimeSinceStartup;
			Time.timeScale = 0;
		} else if (isPlayerDead && Time.timeScale == 0) {
			if (Time.realtimeSinceStartup > timeOfDeath + 2) {
                Instantiate(playerShip, spawnLocation.position, spawnLocation.rotation);
				Time.timeScale = 1;
				isPlayerDead = false;
			}
		}
	}
}
