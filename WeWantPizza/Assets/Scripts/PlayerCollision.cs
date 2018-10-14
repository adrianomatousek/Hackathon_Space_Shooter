using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerCollision : MonoBehaviour {
	public GameObject Player_shattered;
	public string dead = "nothing";
	public RawImage fade;
	public GameObject death_canvas;
	public RawImage died_img;
	public RawImage img_background;

	public GameObject Falcon;

	// Use this for initialization
	void Start () {
		dead = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (dead == "dead") {
			if (Time.timeScale > 0.05f) {
				// Adjust fixed delta time according to timescale
				// The fixed delta time will now be 0.02 frames per real-time second
				Time.timeScale = Time.timeScale - 0.05f;
				Time.fixedDeltaTime = 0.02f*Time.timeScale;

				print (Time.timeScale);
				Color new_color = fade.color;

				new_color.a += 0.01f;
				fade.color = new_color;
				Color death = died_img.color;
				death.a = died_img.color.a + 0.05f;
				died_img.color = death;
				img_background.color = new_color * 5;
			}
		}
	}

	void OnCollisionEnter(Collision collision)	{
		if (collision.gameObject.tag == "hostile_object") {
			death_canvas.SetActive (true);
			print ("You lost the game");
			dead = "dead";
			Player_shattered.transform.position = transform.position;
			//Player_shattered.SetActive (true);
			//gameObject.SetActive (false);
			AddRigidBodies();
			StartCoroutine(restart());
		}
	}

	IEnumerator restart() {
		yield return new WaitForSecondsRealtime (4f);
		Time.timeScale = 1;
		Time.fixedDeltaTime = 0.02f;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	void AddRigidBodies(){
		foreach (Transform child in Falcon.transform) {
			foreach (Transform piece in child) {
				if (!piece.gameObject.GetComponent<Rigidbody> ()) {
					piece.gameObject.AddComponent<MeshCollider> ();
					piece.gameObject.GetComponent<MeshCollider> ().convex = true;

					piece.gameObject.AddComponent<Rigidbody> ();
					piece.gameObject.GetComponent<Rigidbody>().useGravity = false;
				}
			}
		}
	}


}
