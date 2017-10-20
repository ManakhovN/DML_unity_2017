using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    Vector3 startingScale = new Vector3();
    Material mat;
    // Use this for initialization
    void Start()
    {
        startingScale = transform.localScale;
        mat = GetComponent<MeshRenderer>().material;
    }
    float multiplier = 1f;
    bool growingUp = true;
    // Update is called once per frame
    void Update()
    {
        //if (multiplier <= 2f && growingUp)
        //{
        //    multiplier += Time.deltaTime;
        //}
        //else
        //    if (multiplier >= 0f && !growingUp)
        //{
        //    multiplier -= Time.deltaTime;
        //}
        //else
        //    growingUp = !growingUp;
        //transform.localScale = multiplier * startingScale;

        mat.color = Color.red * Mathf.Sin(Time.time);
        transform.localScale = Mathf.Sin(Time.time) * startingScale;

        // transform.localScale = Mathf.Tan(Time.time) * startingScale;
    }
}
