using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
			ResetGame();
			SceneManager.LoadScene("Game_Over");
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

	void ResetGame() {
		isPlayerDead = false;
		LevelController.level = 1;
		PlayerScore.playerScore = 0;
		PlayerLifeSystem.playerLives = 3;
	}
}
