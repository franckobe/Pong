using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

    string wallName;
    int direction;

	// Use this for initialization
	void Start () {
        wallName = gameObject.name;
        if (wallName == "wall_center_1") direction = -1;
        if (wallName == "wall_center_2") direction = 1;
    }
	
	// Update is called once per frame
	void Update () {

        if (wallName == "wall_center_1")
        {
            if (transform.position.z <= 2.75 || transform.position.z >= 6) direction *= -1;
        }
        if (wallName == "wall_center_2")
        {
            if (transform.position.z >= -2.25 || transform.position.z <= -6) direction *= -1;
        }
        transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z + (0.10f * direction));

    }
}
