using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

  
    private Transform bullet;
	public float speed;

	void Start () {
		bullet = GetComponent<Transform>();

	}
	
    void FixedUpdate() {
		bullet.position += Vector3.up * -speed;

        if (bullet.position.y <= -7.5) {
			Destroy(bullet.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			Destroy(other.gameObject);
			PlayerLifeSystem.playerLives--;
			Destroy(bullet.gameObject);
			GameOver.isPlayerDead = true;
		} else if (other.tag == "Shield") {
            GameObject playerShield = other.gameObject;
			ShieldHealth shieldHealth = playerShield.GetComponent<ShieldHealth>();
			shieldHealth.health -= 1;
			Destroy(bullet.gameObject);
		}
	}
}
