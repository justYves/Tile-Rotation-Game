using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

	// Use this for initialization
	void Awake() {
		DontDestroyOnLoad(this.gameObject);
	}
}