using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
	// public GameObject[] prefabs = new GameObject[1];
	public List<GameObject> prefabList = new List<GameObject>();
	public int width;
	public int height;

	// public Map map;
	// Use this for initialization
	// void Start () {
		// Vector2 mapSize = getMapSize();

		// map.width = (int) mapSize.x;
		// map.height = (int) mapSize.y;

		// map.tiles = new tile[map.width, map.height];

		// GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
		// foreach (var tile in tiles) {
		// 	map.tiles[(int) tile.transform.position.x, (int) tile.transform.position.y] = tile.GetComponent<tile>();
		// }
		// foreach (var tile in map.tiles) {
		// 	Debug.Log(tile.gameObject.name);
		// }
	// }

	void Start(){
		// int prefabIndex = UnityEngine.Random.Range(0,prefabList.Count-1);
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				Vector2 position = new Vector2(x,y);
				GameObject tile = Instantiate(prefabList[Random.Range(0, prefabList.Count)]);
				tile.transform.position = position;
			}
		}
    }

	void Update () {
		
	}
}
