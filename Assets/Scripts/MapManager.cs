using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
	// public GameObject[] prefabs = new GameObject[1];
	public List<GameObject> prefabList = new List<GameObject>();

	public GameObject character;
	public int width;
	public int height;

	void Start(){
		// int prefabIndex = UnityEngine.Random.Range(0,prefabList.Count-1);
		createMap();
		shuffleMap();
		spawnCharacter();
    }

	void createMap() {
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				Vector2 position = new Vector2(x,y);
				int prefabIndex;
				if (Random.Range(0, 100) > 90) {
					prefabIndex = prefabList.Count - 1;
				} else {
					prefabIndex = Random.Range(0, prefabList.Count-1);
				}
				GameObject tile = Instantiate(prefabList[prefabIndex]);
				tile.transform.position = position;
			}
		}
	}

	void shuffleMap() {
		foreach (var currentTile in GameObject.FindGameObjectsWithTag("Tile")) {
			int rand = Random.Range(0,4);

			for (int i = 0; i < rand; i++) {
				currentTile.GetComponent<Tile>().rotateTile();
			}
		}
	}

	void spawnCharacter() {
		Vector3 position = new Vector3(0, 0, -1);
		GameObject tile = Instantiate(character);
		tile.transform.position = position;
	}

	void Update () {
		
	}
}
