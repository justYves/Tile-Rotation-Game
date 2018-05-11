using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
	// public GameObject[] prefabs = new GameObject[1];
	public List<GameObject> prefabList = new List<GameObject>();
	public GameObject[,] map;
	public GameObject character;
	public int width;
	public int height;

	private float startingX = 0f;
	private float startingY = 0f;

	public GameObject nextTile;

	void Start(){
		createMap();
		shuffleMap();
		spawnCharacter();
    }

	void Update () {
		if (character.GetComponent<Character>().hasReachedDestination) {
			Debug.Log("reached destination!");
			
		}
	}

	void createMap() {
		map = new GameObject[width, height];
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				Vector2 position = new Vector2(x,y);
				int prefabIndex;
				if (x == 0 && y == 0) {
					// populate a line n 0,0
					prefabIndex = 0;
				}
				else if (Random.Range(0, 100) > 90) {
					prefabIndex = prefabList.Count - 1;
				} else {
					prefabIndex = Random.Range(0, prefabList.Count-1);
				}
				GameObject tile = Instantiate(prefabList[prefabIndex]);
				map[x,y] = tile;
				tile.transform.position = position;
			}
		}
	}

	void shuffleMap() {
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				int rand;
				if(x == 0 && y ==0) {
					rand = 0;
				} else {
					rand = Random.Range(0,4);
				}

				for (int i = 0; i < rand; i++) {
					map[x,y].GetComponent<Tile>().rotateTile();
				}

			}
		}
	}

	public GameObject getTileAt(int x,int y) {
		return map[x,y];
	}

	void spawnCharacter() {
		Vector3 position = new Vector3(0, -0.5f, -1);
		character = Instantiate(character);
		character.transform.position = position;
		character.GetComponent<Character>().setDestination(startingX, startingY);
		nextTile = getTileAt(0,0);
	}
}
