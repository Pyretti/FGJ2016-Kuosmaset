using UnityEngine;
using System.Collections;

public class PlayerBase : MonoBehaviour {
    private bool alive = true;

    public void playerDied() {
        alive = false;
    }

    public bool GetAlive() {
        return alive;
    }

}
