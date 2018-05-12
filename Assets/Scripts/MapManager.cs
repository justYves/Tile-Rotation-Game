using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Exception = System.Exception;

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
	private GameObject previousTile;

	public GameObject scoreText;
	public GameObject globalScore;
	private int score; 

	void Start(){
		createMap();
		shuffleMap();
		spawnCharacter();
		resetScore();
    }

	void resetScore() {
		globalScore.GetComponent<Score>().score = 0;
	}

	void Update () {
		if (character.GetComponent<Character>().hasReachedDestination) {
			character.GetComponent<Character>().hasReachedDestination = false;
			string dirString = character.GetComponent<Character>().directionString;
			Vector3 currentPos = character.GetComponent<Character>().transform.position;
			Vector2 newDestination = nextTile.GetComponent<Tile>().getExitDirection(dirString);

			try {
				if (currentPos.x == newDestination.x && currentPos.y == newDestination.y) {
					updateScore();
					// At Edge Going to Center
					previousTile = nextTile;
					newDestination = nextTile.GetComponent<Tile>().getNextTile(dirString);
					nextTile = getTileAt(
						(int) Mathf.Round(newDestination.x),
						(int) Mathf.Round(newDestination.y)
					);
					nextTile.GetComponent<Tile>().setFixed();
					if (!nextTile.GetComponent<Tile>().hasEntrance(dirString)) {
						throw new Exception("Bumping into a Wall, Sorry not Sorry!");
					}
					character.GetComponent<Character>().setDestination(newDestination.x, newDestination.y);
				
				} else if (newDestination.x % 1 != 0 || newDestination.y % 1 != 0) {
					// At center going to an edge
					if (previousTile) {
						replaceTile(previousTile);
					}

					character.GetComponent<Character>().setDestination(newDestination.x, newDestination.y);
				} else {

					nextTile = getTileAt(
						(int) Mathf.Round(newDestination.x),
						(int) Mathf.Round(newDestination.y)
					);
				}
			} catch {
				// catching exception for gameover state
				SceneManager.LoadScene("GameOverScene");
			}
		}
	}
	
	/**
	 * Updates Scores and 
	 */	
	void updateScore() {
		scoreText.GetComponent<UnityEngine.UI.Text>().text = "Scores: " + (++score).ToString();
		globalScore.GetComponent<Score>().score = score;
		character.GetComponent<Character>().speed += 0.1f;
	}

	/**
	 * Creates map
	 */	
	 void createMap() {
		map = new GameObject[width, height];
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				Vector2 position = new Vector2(x,y);
				int prefabIndex;
				if (x == 0 && y == 0) {
					prefabIndex = 0;
				} else {
					prefabIndex = Random.Range(0, prefabList.Count);
				}
				GameObject tile = Instantiate(prefabList[prefabIndex]);
				map[x,y] = tile;
				tile.transform.position = position;
			}
		}
	}
	
	/**
	 * Creates a new Tile and destroys the previous one
	 */
	void replaceTile(GameObject previousTile) {
		int x = (int) previousTile.transform.position.x;
		int y = (int) previousTile.transform.position.y;
		Destroy(previousTile);
		createNewTile(x, y);
	}

	/**
	 * Creates a new Tile
	 */
	void createNewTile(int x, int y) {
		Vector2 position = new Vector2(x,y);
		int prefabIndex;
		map[x,y] = null;

		prefabIndex = Random.Range(0, prefabList.Count);

		GameObject tile = Instantiate(prefabList[prefabIndex]);
		map[x,y] = tile;
		tile.transform.position = position;
		shuffleTile(x,y);
	}

	/**
	 * Shuffles all tiles after creation
	 */
	void shuffleMap() {
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				shuffleTile(x,y);
			}
		}
	}

	/**
	 * Shuffles a single tile
	 */
	void shuffleTile(int x, int y) {
		int rand = Random.Range(0,4);

		for (int i = 0; i < rand; i++) {
			map[x,y].GetComponent<Tile>().rotateTile();
		}
	}

	/**
	 * Helper function to retrieve a tile
	 */
	public GameObject getTileAt(int x,int y) {
		return map[x,y];
	}

	/**
	 * Spawns the player at (0,0.5) 
	 * With 'UP' Direction
	 */
	void spawnCharacter() {
		Vector3 position = new Vector3(0, -0.5f, -1);
		character = Instantiate(character);
		character.transform.position = position;
		character.GetComponent<Character>().setDestination(startingX, startingY);
		nextTile = getTileAt(0,0);
		nextTile.GetComponent<Tile>().setFixed();
	}
}
