using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartHandler : MonoBehaviour {
	public void goToGameScene() {
		SceneManager.LoadScene("GameScene");
	}
}
