using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager instance_;
    public static GameManager Instance {
        get {
            if (instance_ == null)
                instance_ = GameObject.FindObjectOfType<GameManager>();
            return instance_;
        }
    }
    public GameInfo gameInfo = new GameInfo();
    public void Awake()
    {
        if (instance_ != null && instance_ != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        gameInfo.playingTime = Time.time;
    }

    public void AddPoints(int delta)
    {
        gameInfo.score += delta;
    }
}
