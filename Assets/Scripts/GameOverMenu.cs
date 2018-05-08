using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public void ReplayGame() {
        SceneManager.LoadScene("main_scene");
	}

	public void MainMenu() {
		SceneManager.LoadScene("Main_Menu");
	}
}
