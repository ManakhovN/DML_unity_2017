using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RotateButtonsLogic : MonoBehaviour {
    public Transform target;
    public float speed = 10f;
    public void RotateLeft()
    {
        target.Rotate(0f, speed, 0f);
    }

    public void RotateRight()
    {
        target.Rotate(0f, -speed, 0f);
    }

    public void LoadScene(string s)
    {
        DontDestroyOnLoad(target.gameObject);
        SceneManager.LoadScene(s);        
    }
}
