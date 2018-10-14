using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 15);
		//StartCoroutine (AddRigidBody());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator AddRigidBody (){
		yield return new WaitForSeconds (3);

		if (transform.gameObject.tag == "hostile_object") {
			print ("Adding rb");
			Vector3 new_velocity = transform.gameObject.GetComponent<Rigidbody> ().velocity;
			//Destroy (GetComponent<Rigidbody>());
			//collision.gameObject.SetActive (false);
			//collision.gameObject.SetActive (false); Shattered asteroid

			//Transform shattered_asteroid = Instantiate(ShatteredAsteroid, collision.transform.position, collision.transform.rotation);
			//Transform[] children = shattered_asteroid.GetComponentsInChildren<Transform>();

			Transform[] children = transform.gameObject.GetComponentsInChildren<Transform>();
			transform.DetachChildren();
			foreach (Transform child in children) {
				child.gameObject.AddComponent<Rigidbody> ();
				child.gameObject.GetComponent<Rigidbody>().AddForce (new_velocity*50, ForceMode.Force);
				child.gameObject.GetComponent<Rigidbody>().useGravity = false;
				child.gameObject.AddComponent<GravityTest> ();


				//child.gameObject.GetComponent<Rigidbody>().isKinematic = false;
				print ("New velocity: " + new_velocity);
			}
		}

	}
}
