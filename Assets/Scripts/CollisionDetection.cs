using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {
    void OnCollisionEnter(Collision c)
    {
        Debug.Log(c.gameObject.name);
        c.gameObject.GetComponent<Rigidbody>().
            AddForce(Vector3.up*1000.0f);
    }
}
