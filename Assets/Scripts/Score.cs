using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
	public int score = 0;
	void Awake() {
		DontDestroyOnLoad(this.gameObject);
	}

}