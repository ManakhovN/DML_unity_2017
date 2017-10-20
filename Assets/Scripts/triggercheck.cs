using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggercheck : MonoBehaviour {

	    void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.gameObject.name);
    }
}
