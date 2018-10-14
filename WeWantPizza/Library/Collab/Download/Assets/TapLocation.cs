using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapLocation : MonoBehaviour {

    void Update () {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log("Touch Position (x): " + touch.position.x);
            Debug.Log("Touch Position (y): " + touch.position.y);
        }

    }
}
