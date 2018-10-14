using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectGenerator : MonoBehaviour {
	public Transform HostileObject;
	public int var1;
	public Vector3 randomPos;
	public float asteroidTimeout;
	public static int speed;

	//public Text score;

	// Use this for initialization
	void Start () {
		StartCoroutine(GenerateAsteroid());
		asteroidTimeout = 5f;
		speed = 300;
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator GenerateAsteroid() {
		while (true) {
			//print ("Generated an object");
			randomPos = new Vector3 (transform.position.x - 20 + Random.value*40, transform.position.y + Random.value*15, transform.position.z);
			Instantiate(HostileObject, randomPos, Random.rotation);
			yield return new WaitForSeconds (asteroidTimeout);
			Text Score = GameObject.Find ("Score").GetComponent<Text>();
			string[] prev_score = Score.text.Split (new string[] {"core: ", "\n"}, System.StringSplitOptions.None);
			Score.text = "Score: " + (int.Parse(prev_score[1]) + 1).ToString();
			DifficultyManager (int.Parse(prev_score[1]));
		}
	}

	void DifficultyManager(int score) {
        if (score > 5) {
            asteroidTimeout = 5f;
            speed = 600;
        }
        if (score > 10) {
            asteroidTimeout = 4f;
            speed = 800;
        }
        if (score > 15)
        {
            asteroidTimeout = 4f;
            speed = 1000;
        }
        if (score > 20)
        {
            asteroidTimeout = 3f;
            speed = 1000;
        }
        if (score > 30)
        {
            asteroidTimeout = 3f;
            speed = 1300;
        }
        if (score > 40)
        {
            asteroidTimeout = 2f;
            speed = 1300;

        }
        if (score > 50)
        {
            asteroidTimeout = 2f;
            speed = 1600;
        }


        }

	}

