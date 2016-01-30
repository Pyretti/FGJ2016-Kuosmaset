using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public PlayerBase[] playerBases;
    public GameObject[] playerScripts;
    public float gameRoundTimer; //Kokonaisaika
    public float roundTimer = 30f; //Kun tiputellaan uusia
    
    private bool gameRunning = true;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (gameRunning) { 
            gameRoundTimer += Time.deltaTime;
	        for(int i = 0; i < playerBases.Length; i++) {
                if (!playerBases[i].GetAlive()) {
                    gameRunning = false;
                }
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
