using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour {
    
	private Transform enemyHolder;
	public static float speed = 0.20f + (LevelController.level * 0.01f);
    public GameObject shot;
	public static float fireRate = 0.997f - (LevelController.level * 0.001f);

	// Use this for initialization
	void Start () {
		InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
		enemyHolder = GetComponent<Transform>();
	}
	
    void MoveEnemy () {

		enemyHolder.position += Vector3.right * speed;

		foreach (Transform enemy in enemyHolder) {
            if (enemy.position.x <= -6 || enemy.position.x >= 6) {
				speed = -speed;
				enemyHolder.position += Vector3.down * 0.5f;
				return;
			}

			// Enemy bullet logic
			if (Random.value > fireRate) {
				Instantiate (shot, enemy.position, enemy.rotation);
			}

			if (enemy.position.y <= -2.5) {
				PlayerLifeSystem.playerLives = 0;
				GameOver.isPlayerDead = true;
				Time.timeScale = 0;
			}
		}

        if (enemyHolder.childCount == 1) {
			CancelInvoke();
			InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
		}

		if (enemyHolder.childCount == 0 && Time.timeScale == 1) {
			LevelController.didPlayerWin = true;
			LevelController.level++;
			LevelController.levelTracker.text = "Victory! Now Starting Level " + LevelController.level;
			LevelController.levelTracker.enabled = true;
			Time.timeScale = 0;
		}
	}
}
