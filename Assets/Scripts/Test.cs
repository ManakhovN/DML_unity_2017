using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public float speed = 10f;
	void Update () {
        Vector3 axis = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += axis * Time.deltaTime* speed;
	}
}
