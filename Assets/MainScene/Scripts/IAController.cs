using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour {

    public GameObject ball;
    float initialstep = 0.2f;
    float step = 0.25f;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(10.0f,0.0f,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        
        if (ball.transform.position.x > -2)
        {
            if (System.Math.Round(ball.transform.position.z) > System.Math.Round(transform.position.z))
            {
                rb.MovePosition(new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z + step
                ));
            }
            if (ball.transform.position.z < transform.position.z)
            {
                rb.MovePosition(new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z - step
                ));
            }
        }
        else
        {
            if (transform.position.z < 0)
            {
                rb.MovePosition (new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z + initialstep
                ));
            }
            if (transform.position.z > 0)
            {
                rb.MovePosition ( new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z - initialstep
                ));
            }
        }
    }
}
