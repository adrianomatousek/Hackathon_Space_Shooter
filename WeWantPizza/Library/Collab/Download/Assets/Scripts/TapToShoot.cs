using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToShoot : MonoBehaviour
{
    public GameObject projectile;
    public float bulletSpeed;

    void Update()
    {

        if (Input.touchCount > 0)
        {

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(r.origin, r.direction * 10, Color.cyan);
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Vector2 dir = touchPos - (new Vector2(transform.position.x, transform.position.y));
                dir.Normalize();
                GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<Rigidbody>().velocity = dir * bulletSpeed;
            }
        }
    }
}

