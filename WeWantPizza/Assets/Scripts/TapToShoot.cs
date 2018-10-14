using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToShoot : MonoBehaviour
{
    public GameObject projectile;
    public float bulletSpeed;


	void Start() {
		bulletSpeed = 50;
		ChangeAmmo (9);
	}

    void Update()
    {

		if (Input.touchCount > 0)
        {
			Text Ammo = GameObject.Find ("Ammunition").GetComponent<Text>();
			string[] prev_ammo = Ammo.text.Split (new string[] {"mmo: ", "\n"}, System.StringSplitOptions.None);

			if (Input.GetTouch(0).phase == TouchPhase.Began && int.Parse(prev_ammo[1]) > 0)
            {
				var mousePos = new Vector3 (Input.mousePosition.x*1.1f, Input.mousePosition.y * 1.2f + 5, 0);
				Ray r = Camera.main.ScreenPointToRay(mousePos);
                Debug.DrawRay(r.origin, r.direction * 10, Color.cyan);
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				Vector3 dir = (new Vector3(touchPos.x,touchPos.y,0)) - (new Vector3(transform.position.x, transform.position.y, 0));
                dir.Normalize();
				var spawnPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 1.5f);
				GameObject bullet = Instantiate(projectile, spawnPos, Quaternion.identity) as GameObject;
				bullet.GetComponent<Rigidbody>().velocity = r.direction * bulletSpeed;
				ChangeAmmo (-1);
            }
		} else if (Input.GetMouseButtonDown(0) && Application.isEditor)//Below is the same as above but for mouse clicks
		{
			Text Ammo = GameObject.Find ("Ammunition").GetComponent<Text>();
			string[] prev_ammo = Ammo.text.Split (new string[] {"mmo: ", "\n"}, System.StringSplitOptions.None);
			if (int.Parse (prev_ammo [1]) > 0) {
				var mousePos = new Vector3 (Input.mousePosition.x * 1.1f, Input.mousePosition.y * 1.2f + 5, 0);
				Ray r = Camera.main.ScreenPointToRay (mousePos);
				Debug.DrawRay (r.origin, r.direction * 10, Color.cyan);
				Vector2 touchPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector3 dir = (new Vector3 (touchPos.x, touchPos.y, 0)) - (new Vector3 (transform.position.x, transform.position.y, 0));
				dir.Normalize ();
				var spawnPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 1.5f);
				GameObject bullet = Instantiate (projectile, spawnPos, Quaternion.identity) as GameObject;
				bullet.GetComponent<Rigidbody> ().velocity = r.direction * bulletSpeed;
				ChangeAmmo (-1);
			}
		}
    }

	void ChangeAmmo(int change) {
		Text Ammo = GameObject.Find ("Ammunition").GetComponent<Text>();
		string[] prev_ammo = Ammo.text.Split (new string[] {"mmo: ", "\n"}, System.StringSplitOptions.None);
		Ammo.text = "Ammo: " + (int.Parse(prev_ammo[1]) + change).ToString();
	}
}

