using UnityEngine;
using System.Collections;
/// <summary>
/// TODO:
/// GameManager: (Jukka)
///     Tippuu tyypit taivaalta (Ajastimella 30 sek välein)
/// 
/// Animaation jahka tulee
///     Grafiikat:
///     - salama
///     - linnut
/// Äänet
/// Intropätkä
/// EndScreen (Jouko)
/// EndGame (Pyry)
/// Hifistelee jos kerkee
///     -Pause
/// </summary>
public class GameManager : MonoBehaviour {
    public PlayerBase[] playerBases;
    public GameObject[] playerScripts;
    public float gameRoundTimer; //Kokonaisaika
    public float roundTimer = 30f; //Kun tiputellaan uusia
    public GameObject endMenuCanvas;
    
    private bool gameRunning = true;
	// Update is called once per frame
	void Update () {
        if (gameRunning) { 
            gameRoundTimer += Time.deltaTime;
	        for(int i = 0; i < playerBases.Length; i++) {
                if (!playerBases[i].GetAlive()) {
                    gameRunning = false;

                    endMenuCanvas.SetActive(true);
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

/// <summary>
/// Hakee gamemanagerista suoraan ajan ja formatoi sen.
/// </summary>
public class SecondTime : GameManager
{
    public float min { get; set; }
    public float sec { get; set; }
    public float ms { get; set; }
    public string formatedTime;

    public SecondTime() {
        float time = base.gameRoundTimer;
        min = Mathf.Floor(time / 60);
        sec = Mathf.RoundToInt(time % 60);
        ms = Mathf.Floor(time * 1000) % 1000;

        formatedTime = string.Format("{0:00}:{1:00}:{2:000}", min, sec, ms);
    }
}