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
    public float gameRoundTimer = 0f; //Kokonaisaika
    public float roundTimer = 30f; //Kun tiputellaan uusia
    public GameObject endMenuCanvas;
    
    private bool gameRunning = true;

    void Start() {
        Debug.Log(new SecondTime(1000f).formatedTime);
    }

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
}

/// <summary>
/// Hakee gamemanagerista suoraan ajan ja formatoi sen.
/// </summary>
public class SecondTime
{
    public float min { get; set; }
    public float sec { get; set; }
    public float ms { get; set; }
    public string formatedTime { get; set; }

    public SecondTime(float time) {
        //float time = base.gameRoundTimer;
        min = Mathf.Floor(time / 60);
        sec = Mathf.RoundToInt(time % 60);
        ms = Mathf.Floor(time * 1000) % 1000;

        formatedTime = string.Format("{0:00}:{1:00}:{2:000}", min, sec, ms);
    }
}