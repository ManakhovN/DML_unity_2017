using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimatorParam : MonoBehaviour {
    Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            animator.SetTrigger("Trig");
        if (Input.GetKeyDown(KeyCode.X))
            animator.SetTrigger("DeathTrigger");
    }
    	
}
