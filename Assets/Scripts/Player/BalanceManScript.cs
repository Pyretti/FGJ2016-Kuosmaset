using UnityEngine;
using System.Collections;

public class BalanceManScript : MonoBehaviour {

    /// <summary>
    /// tätä kautta kiertää GameManagerille info että joku on falennu.
    /// Kutsu playerDied() -funktiota (ei ota paroja)
    /// </summary>
    PlayerBase pb;  
	Transform transform;
	bool failed;
	public float fallSpeed = 40;
	bool _online;
	// Use this for initialization
	void Start () {
        pb = GetComponent<PlayerBase>();
		transform = this.GetComponent<Transform>();
		failed = false;
		_online = false;

		goOnline ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_online) {
			if (!failed) {
				float fallSpeed = 0;
				if (HasMouseMovedLeft ()) {
					fallSpeed = Input.GetAxis ("Mouse X");
				} else if (HasMouseMovedRight ()) {
					fallSpeed = Input.GetAxis ("Mouse X");
				} else {
					fallToSide ();
				}

				transform.Rotate (Vector3.forward * 100 * fallSpeed * Time.deltaTime);
				if (FallState ()) {
					this.failed = true;
				}
			} else {
				GameOverFall ();
			}
		}
	}
 	public	void goOnline(){
		this._online = true;
	}

	void GameOverFall(){
		int multiPlier = 1;
		if (transform.rotation.eulerAngles.z > 180) {
			multiPlier = multiPlier * -1;
		}
		if ((transform.rotation.eulerAngles.z < 100) || (transform.rotation.eulerAngles.z > 260)) {
			transform.Rotate(Vector3.forward * 200 * multiPlier * Time.deltaTime);
		}
	}

	void fallToSide(){
		float currentRotation = transform.rotation.eulerAngles.z;
		float moveRotation = fallSpeed;
		float FallMultiplier;
		if (currentRotation > 180) {
			moveRotation = moveRotation * -1;
			FallMultiplier = (360 - currentRotation) / 5;
		}
		else{
			FallMultiplier = currentRotation / 5;
		}

		transform.Rotate(Vector3.forward * moveRotation * 0.2f * FallMultiplier * Time.deltaTime);
	}
	bool HasMouseMovedLeft(){
		return (Input.GetAxis("Mouse X") < 0);
	}
	bool HasMouseMovedRight(){
		return (Input.GetAxis("Mouse X") > 0);
	}

	bool FallState()
	{
		return ((transform.rotation.eulerAngles.z > 65) && (transform.rotation.eulerAngles.z < 295));
	}
}
