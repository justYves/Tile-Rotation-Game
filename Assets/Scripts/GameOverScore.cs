using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScore : MonoBehaviour {
	public GameObject scoreText;
	// Use this for initialization
	void Start() {
		int score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().score; 
		scoreText.GetComponent<UnityEngine.UI.Text>().text = "Scores: " + (score).ToString();
	}

	void onMouseDown() {
		Debug.Log("This is about to gow down");
	}
}