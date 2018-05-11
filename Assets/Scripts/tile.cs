using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
	float rotation;
	float rotationIncrement = 90;

	float positionIncrement = 0.5f;
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
		rotateTile();
	}

	public void rotateTile() {
		rotation += rotationIncrement;
		rotation = rotation == 360 ? 0 : rotation;
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

	public Vector2 getExitDirection(string direction) {
		float x = transform.position.x;
		float y = transform.position.y;
		// Debug.Log(direction);

		switch(direction) {
			case "UP":
				if (roadValues[0] == 1) {
					return new Vector2(x, y + positionIncrement);
				} else if (roadValues[1] == 1) {
					return new Vector2(x + positionIncrement, y);
				} else if (roadValues[3] == 1) {
					return new Vector2(x - positionIncrement, y);
				}
				break;
			case "RIGHT":
				if (roadValues[1] == 1) {
					return new Vector2(x + positionIncrement, y);
				} else if (roadValues[0] == 1) {
					return new Vector2(x, y + positionIncrement);
				} else if (roadValues[2] == 1) {
					return new Vector2(x, y - positionIncrement);
				}
				break;
			case "DOWN":
				if (roadValues[2] == 1) {
					return new Vector2(x, y - positionIncrement);
				} else if (roadValues[1] == 1) {
					return new Vector2(x + positionIncrement, y);
				} else if (roadValues[3] == 1) {
					return new Vector2(x - positionIncrement, y);
				}
				break;
			case "LEFT":
				if (roadValues[3] == 1) {
					return new Vector2(x - positionIncrement, y);
				} else if (roadValues[0] == 1) {
					return new Vector2(x, y + positionIncrement);
				} else if (roadValues[2] == 1) {
					return new Vector2(x, y - positionIncrement);
				}
				break;
		}
		// not possible: game over
		return new Vector2(-1, -1);
	}

	public Vector2 getNextTile(string direction) {
		float x = transform.position.x;
		float y = transform.position.y;
		switch(direction) {
			case "UP":
				return new Vector2(x, y + 1);
				break;
			case "RIGHT":
				return new Vector2(x + 1, y);
				break;
			case "DOWN":
				return new Vector2(x, y - 1);
				break;
			case "LEFT":
				return new Vector2(x - 1, y);
				break;
		}
		return new Vector2(-1, -1);
	}
}
