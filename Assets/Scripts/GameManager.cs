using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public PlayerBase[] playerBases;
	public GameObject[] dudeObjects;
    public float gameRoundTimer; //Kokonaisaika
    public float roundTimer = 30f; //Kun tiputellaan uusia
    
	private GameObject descending;
	private float spawnY;
	private float descendY;
	private int baseCounter;
	private float _roudTimer;
    private bool gameRunning = true;

	// Use this for initialization
	void Start () {
		baseCounter = 1;
		_roudTimer = roundTimer;

		//spawnY = Screen.height;
		spawnY = 10;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameRunning) { 
            gameRoundTimer += Time.deltaTime;
			for(int i = 0; i < baseCounter; i++) {
                if (!playerBases[i].GetAlive()) {
                    gameRunning = false;
                }
            }

			if(baseCounter < playerBases.Length){
				_roudTimer -= Time.deltaTime;

				if(_roudTimer <= 0){
					_roudTimer = roundTimer;
					SpawnNext();
					baseCounter++;
				}
			}
        }
		floatDown ();
    }

	private void SpawnNext(){
		//Debug.Log ("NEXT");
		descendY = 4;
		descending = Instantiate (dudeObjects[baseCounter], new Vector2(dudeObjects[baseCounter].transform.position.x, spawnY), Quaternion.identity) as GameObject;
	}

	private void floatDown(){
		if (descending != null) {
			if(descending.transform.position.y > descendY){
				descending.transform.position = new Vector2(descending.transform.position.x, descending.transform.position.y - 3f * Time.deltaTime);
			}
			else{
			}
		}

	}
    /// <summary>
    /// Palauttaa ajan stringinä
    /// </summary>
    public string ReturnTime() {
        string minutes = Mathf.Floor(gameRoundTimer / 60).ToString("00");
        string seconds = Mathf.RoundToInt(gameRoundTimer % 60).ToString("00");
        float milseconds = Mathf.Floor(gameRoundTimer * 1000) % 1000;
        string ms = milseconds.ToString("000");

        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, ms);
    }
}
