using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effects : MonoBehaviour {


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("wall_back"))
        {
            GameObject obj = Resources.Load<GameObject>("ExplosionMobile");
            if (obj != null)
            {
                obj = Instantiate(obj);
                obj.transform.position = collision.contacts[0].point;

                Destroy(obj, 4);
            }
        }
        if (collision.gameObject.name.Equals("wall"))
        {
            GameObject obj = Resources.Load<GameObject>("Flare");
            if (obj != null)
            {
                obj = Instantiate(obj);
                obj.transform.position = collision.contacts[0].point;

                Destroy(obj, 4);
            }
        }
    }


}
