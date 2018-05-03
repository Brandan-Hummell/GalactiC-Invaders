using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public static int level = 1;

	public static bool didPlayerWin = false;

	public static Text levelTracker;

	private float levelEnd;

	private static float scoreTracker;

	// Use this for initialization
	void Start () {
        levelTracker = GetComponent<Text>();
		levelTracker.enabled = false;
	}

	void Update() {
		if (didPlayerWin == true) {
			NextLevel();
			didPlayerWin = false;
		}
	}
	
	private void NextLevel() {
		levelEnd = Time.realtimeSinceStartup;
		scoreTracker = PlayerScore.playerScore;
		while (Time.timeScale == 0) {
             if (Time.realtimeSinceStartup > levelEnd + 3) {
			    levelTracker.enabled = false;
                SceneManager.LoadScene("main_scene");
                PlayerScore.playerScore = scoreTracker;
			    Time.timeScale = 1;
		    }
		}

	}
    
}
