using UnityEngine;
using System.Collections;

public class BowingManScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeAnimator() {
        //TODO: TEE LOPPUUN
    }

    public void hasFailed() {
        GetComponent<PlayerBase>().playerDied();
    }
}
