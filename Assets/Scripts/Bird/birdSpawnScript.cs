using UnityEngine;
using System.Collections;

public class birdSpawnScript : MonoBehaviour {

	float BirdSpawnTime;
	float spawnNext;

	public float spawnHeight;
	public GameObject spawnObject;

	float minSpawn;
	float maxSPawn;
	// Use this for initialization
	void Start () {
		BirdSpawnTime = getRandom ();
		spawnNext = BirdSpawnTime;

		minSpawn = transform.position.y - (transform.lossyScale.y / 2);
		maxSPawn = transform.position.y + (transform.lossyScale.y / 2);
	}
	
	// Update is called once per frame
	void Update () {
		spawnNext -= Time.deltaTime;

		if (spawnNext <= 0) {
			SpawnObject();

			spawnNext = getRandom();
		}
	}

	private int getRandom(){
		int randomInt = 0;

		randomInt = Random.Range (3, 8);

		return randomInt;
	}

	private void SpawnObject(){
		if (spawnHeight == -1) {

			Instantiate(spawnObject, new Vector2(this.transform.position.x, Random.Range(minSpawn, maxSPawn)), Quaternion.identity);
		}
	}
}
