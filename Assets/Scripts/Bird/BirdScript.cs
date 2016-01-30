using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {
	
	public float flyHeight = 3f;
	public float flySpeed = 0.5f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3( transform.position.x + flySpeed * Time.deltaTime, transform.position.y); 
	}
}
