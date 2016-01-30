using UnityEngine;
using System.Collections;

public class BowingManScript : MonoBehaviour {
    
    public void ChangeAnimator() {
        //TODO: TEE LOPPUUN
    }

    public void hasFailed() {
        GetComponent<PlayerBase>().TakeDmg();
    }
}
