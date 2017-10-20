using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectExample : MonoBehaviour
{

    void Start()
    {

    }
    Stack<GameObject> stack = new Stack<GameObject>();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(0, 10), Random.Range(-10, 10));
            go.AddComponent<Pulse>();
            stack.Push(go);
        }
        if (stack.Count > 0 && Input.GetKeyDown(KeyCode.Backspace))
        {
            GameObject go = stack.Pop();
            Destroy(go);
        }
    }
}
