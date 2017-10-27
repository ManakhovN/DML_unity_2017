using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    
    public enum CurrentState { Walk, Wait, ChangePoint};
    public CurrentState state;
    Vector3 target;
    Vector3 startPoint;
    public float speed;
    void Start () {
        state = CurrentState.ChangePoint;
        startPoint = transform.position;
	}

    float timer = 0f;
	void Update () {
        switch (state)
        {
            case CurrentState.ChangePoint:
                target = startPoint + new Vector3(Random.Range(0f, 4f), Random.Range(0f, 4f));
                state = CurrentState.Walk;
                break;
            case CurrentState.Wait:
                timer -= Time.deltaTime;
                if (timer < 0f)
                    state = CurrentState.ChangePoint;
                break;
            case CurrentState.Walk:
                transform.position = Vector3.MoveTowards(transform.position, 
                        target, Time.deltaTime*speed);
                if (transform.position == target){
                    timer = 1.5f;
                    state = CurrentState.Wait;
                }
                break;
        }
	}
}
