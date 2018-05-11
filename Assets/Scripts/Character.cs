using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	// Use this for initialization
	public float speed = 0.5f;
	public float reachDist = 1.0f;
	public int currentPoint = 0;
	public Transform path;
	public Vector3 direction;
	public GameObject currentTile;

	public float destinationX;
	public float destinationY;
	
	public bool hasReachedDestination;

	public GameObject map;
	public string directionString = "IDLE";

	Vector3 UP = new Vector3(0, 1, 0);
	Vector3 DOWN = new Vector3(0, -1, 0);
	Vector3 LEFT = new Vector3(-1, 0, 0);
	Vector3 RIGHT = new Vector3(1, 0, 0);
	Vector3 IDLE = new Vector3(0, 0, 0);
	void Start () {
		// direction = UP;
		map = GameObject.Find("MapManager");
	}
	
	// Update is called once per frame
	void Update () {
		move();
	}

	void move() {
		hasReachedDestination = checkPassedDestination();
		if (!hasReachedDestination) {
			transform.position += direction * Time.deltaTime * speed; 
		}
	}

	bool checkPassedDestination() {
		switch(directionString) {
			case "UP":
				Debug.Log(destinationY);
				return transform.position.y > destinationY;
			case "DOWN":
				return transform.position.y < destinationY;
			case "LEFT":
				return transform.position.x < destinationX;
			case "RIGHT":
				return transform.position.x > destinationX;
		}
		return true;
	}
	// public void setDirection(string dirStr) {
	// 	directionString = dirStr;
	// 	switch(dirStr) {
	// 		case "UP":
	// 			direction = UP;
	// 			break;
	// 		case "DOWN":
	// 			direction = DOWN;
	// 			break;
	// 		case "LEFT":
	// 			direction = LEFT;
	// 			break;
	// 		case "RIGHT":
	// 			direction = RIGHT;
	// 			break;
	// 	}
	// }

	public void setDestination(float x, float y) {
		destinationX = x;
		destinationY = y;
		if (transform.position.x > x) {
			directionString = "LEFT";
			direction = LEFT;
		} else if (transform.position.x < x) {
			directionString = "RIGHT";
			direction = RIGHT;
		} else if (transform.position.y < y) {
			directionString = "UP";
			direction = UP;
		} else if (transform.position.y > y) {
			directionString = "DOWN";
			direction = DOWN;
		} else {
			directionString = "IDLE";
			direction = IDLE;
		}
		Debug.Log("GOING UP");
	}

	// public void setDestination(GameObject tile) {
	// 	destination = tile;
	// 	if (transform.position.x > tile.transform.position.x) {
	// 		direction = LEFT;
	// 	} else if (transform.position.x < tile.transform.position.x) {
	// 		direction = RIGHT;
	// 	} else if (transform.position.y < tile.transform.position.y) {
	// 		direction = UP;
	// 	} else if (transform.position.y > tile.transform.position.y) {
	// 		direction = DOWN;
	// 	} else {
	// 		direction = IDLE;
	// 	}

	// }
}
