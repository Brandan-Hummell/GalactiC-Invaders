﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    
    private Transform bullet;
	public float speed;

	// Use this for initialization
	void Start () {
		bullet = GetComponent<Transform>();
	}
	
    void FixedUpdate() {
		bullet.position += Vector3.up * speed;

		if (bullet.position.y > 7.5) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Enemy") {
			Destroy(other.gameObject);
			Destroy(gameObject);
			// Increase player score
		} else if (other.tag == "Shield") {
			Destroy(gameObject);
		}
	}
}
