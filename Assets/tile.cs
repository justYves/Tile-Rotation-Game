using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour {
	float rotation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onMouseDown() {
		rotation += 90;

		transform.rotation = Quaternion.Euler(0, 0, rotation);
	}
}
