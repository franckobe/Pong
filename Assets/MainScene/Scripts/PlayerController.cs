using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    float playerStep = 0.5f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // transform.position = new Vector3(transform.position.x,0.0f, ray.GetPoint(8.0f).z);

        rb.velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.Q))
        {
            rb.MovePosition(new Vector3(transform.position.x, 0.0f, transform.position.z + playerStep));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(new Vector3(transform.position.x, 0.0f, transform.position.z - playerStep));
        }

    }
}
