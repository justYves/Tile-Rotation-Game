using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour {
	float rotation;
	float rotationIncrement = 90;
	public int[] roadValues;
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation.eulerAngles.z != rotation) {
			transform.rotation = Quaternion.Lerp(
				transform.rotation,
				Quaternion.Euler(0, 0, rotation),
				speed
			);
		}
	}

	void OnMouseDown() {
		rotation += rotationIncrement;
		rotation = rotation == 360 ? 0 : rotation;
	}

	public void rotateTile() {
		transform.rotation = Quaternion.Euler(0, 0, rotation);
		updateValues();
	}

	public void updateValues() {
		int last = roadValues[0];
		int i = 0;
		while(i < 3) {
			roadValues[i] = roadValues[++i];
		}

		roadValues[3] = last;
	}
}
