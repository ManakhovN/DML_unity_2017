using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCursor : MonoBehaviour {
    public float speed = 100f;
    SpriteRenderer[] sprites;
    Camera cam;
    bool mouseDown = false;
	void Start () {
        sprites = GameObject.FindObjectsOfType<SpriteRenderer>();
        Debug.Log(sprites.Length);
        cam = Camera.main;
	}
	
	void Update () {
         if (Input.GetMouseButton(0))
        {
            Vector3 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0;
            MoveAllSpritesTo(newPos);
        }
	}

    public void MoveAllSpritesTo(Vector3 pos)
    {
        for (int i=0; i<sprites.Length; i++)
        {
            Vector3 currPos = sprites[i].transform.position;
            sprites[i].transform.position = 
                        Vector3.Lerp(currPos, pos, speed * Time.deltaTime);
        }
    }
}
