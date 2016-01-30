using UnityEngine;
using System.Collections;

public class DestroyChild : MonoBehaviour {
    public PlayerBase pb;
    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            if(transform.childCount > 0) {
                Destroy(transform.GetChild(transform.childCount -1).gameObject);
                
            } else {
                pb.TakeDmg();
            }
        }
    }
}
