using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsExample : MonoBehaviour {
    public Text text;
    public InputField score;
    public InputField name;
    void Start () {
        text.text = "Score = " + PlayerPrefs.GetFloat("Score", 0f) +
                        " Name = " + PlayerPrefs.GetString("Name", "Jhon");
	}

    public void Save()
    {
        PlayerPrefs.SetFloat("Score",Single.Parse(score.text));
        PlayerPrefs.SetString("Name", name.text);
        PlayerPrefs.Save();
    }	
}
