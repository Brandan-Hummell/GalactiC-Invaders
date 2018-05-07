using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeSystem : MonoBehaviour {

	public static int playerLives = 3;

	private Text lifeText;
	
	// Use this for initialization
	void Start () {
		lifeText = GetComponent<Text>();
		lifeText.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
		lifeText.text = "Extra Lives: " + playerLives - 1;
	}
}
