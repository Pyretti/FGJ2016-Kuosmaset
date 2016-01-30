using UnityEngine;
using System.Collections;

public class PlayerBase : MonoBehaviour {
    public float hp = 5;
    private bool alive = true;

    public void TakeDmg() {
        hp -= 1f;
    }

    void Update() {
        if(hp <= 0) {
            playerDied();
        }
    }

    public void playerDied() {
        alive = false;
    }

    public bool GetAlive() {
        return alive;
    }
}
