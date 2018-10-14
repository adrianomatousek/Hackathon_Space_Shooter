using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var speed = ObjectGenerator.speed;
		var offset = 2*Mathf.Pow(Random.value,5) - 2*Mathf.Pow(Random.value,5); //Offset favouring low values
		var randomPos = new Vector3 (offset,offset,offset);
		//transform.LookAt (player.transform);
		transform.LookAt(randomPos);
		gameObject.GetComponent<Rigidbody>().AddRelativeForce (Vector3.forward * speed*transform.GetComponent<Rigidbody>().mass, ForceMode.Force);
		var rot_factor = 10;
		gameObject.GetComponent<Rigidbody>().AddRelativeTorque (new Vector3(Random.value*rot_factor, Random.value*rot_factor, Random.value*rot_factor));

		Transform[] children = transform.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform child in children) {
			//child.gameObject.AddComponent<Rigidbody> ();
			//child.gameObject.GetComponent<Rigidbody>().AddRelativeForce (new_velocity, ForceMode.Force);
			//child.GetComponent<Rigidbody>().AddRelativeForce (Vector3.forward * speed*child.GetComponent<Rigidbody>().mass, ForceMode.Force);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}
}
