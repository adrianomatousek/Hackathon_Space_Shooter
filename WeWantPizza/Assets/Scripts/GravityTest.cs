using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//transform.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (transform.position.x*2,(transform.position.y-1.5f)*5,0));
		transform.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (transform.position.x*0.2f + 1,(transform.position.y-1.5f) + 1.5f,0.5f));
	}
}
