using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour {
    
	private Transform enemyHolder;
	public float speed;
    public GameObject shot;
	public Text winText;
	public float fireRate = 0.997f;

	// Use this for initialization
	void Start () {
		winText.enabled = false;
		InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
		enemyHolder = GetComponent<Transform>();
	}
	
    void MoveEnemy () {

		enemyHolder.position = Vector3.right * speed;

		foreach (Transform enemy in enemyHolder) {
            if (enemy.position.x <= -6 || enemy.position.x >= 6) {
				speed = -speed;
				enemyHolder.position += Vector3.down * 0.5f;
				return;
			}

			// Enemy bullet logic

			if (enemy.position.y <= -2) {
				GameOver.isPlayerDead = true;
				Time.timeScale = 0;
			}
		}

	    if (enemyHolder.childCount == 1 || enemyHolder.childCount == 2) {
			CancelInvoke();
			InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
		}

		if (enemyHolder.childCount == 0) {
			winText.enabled = true;
			// Logic for resetting the scene for the next level
		}
	}
}
