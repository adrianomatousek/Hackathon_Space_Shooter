using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCollision : MonoBehaviour {
	public Transform ShatteredAsteroid;
	public Transform ExplosionCollider;
	public Text Ammo;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision)	{
		if (collision.gameObject.tag == "hostile_object") {
			AddAmmo ();
			collision.gameObject.tag = "destroyed_hostile";
			print ("Bullet collided with asteroid");
			Vector3 new_velocity = collision.transform.gameObject.GetComponent<Rigidbody> ().velocity;
			//Destroy (GetComponent<Rigidbody>());
			//collision.gameObject.SetActive (false);
			//collision.gameObject.SetActive (false); Shattered asteroid

			//Transform shattered_asteroid = Instantiate(ShatteredAsteroid, collision.transform.position, collision.transform.rotation);
			//Transform[] children = shattered_asteroid.GetComponentsInChildren<Transform>();

			Transform[] children = collision.transform.gameObject.GetComponentsInChildren<Transform>();
			Transform sphere = Instantiate(ExplosionCollider, collision.transform.position, Quaternion.identity);
			Destroy (sphere.gameObject, 2);

			collision.transform.DetachChildren();
			foreach (Transform child in children) {
				child.gameObject.AddComponent<Rigidbody> ();
				child.gameObject.GetComponent<Rigidbody>().AddForce (new_velocity*50, ForceMode.Force);
				//child.gameObject.GetComponent<Rigidbody>().angularVelocity = new_ang_velocity;
				child.gameObject.GetComponent<Rigidbody>().useGravity = false;
				child.gameObject.AddComponent<GravityTest> ();
				Destroy (child.gameObject, 5);
					
				//child.gameObject.GetComponent<Rigidbody>().isKinematic = false;
				//print ("New velocity: " + new_velocity);
			}
		}
	}

	void AddAmmo() {
		Ammo = GameObject.Find ("Ammunition").GetComponent<Text>();
		string[] prev_ammo = Ammo.text.Split (new string[] {"mmo: ", "\n"}, System.StringSplitOptions.None);
		Ammo.text = "Ammo: " + (int.Parse(prev_ammo[1]) + 2).ToString();
	}
}