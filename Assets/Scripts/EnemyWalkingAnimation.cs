using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkingAnimation : MonoBehaviour {

    Animator animator;
    Rigidbody2D rb;

    void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

	void Update () {
        if(Mathf.Abs(rb.velocity.x) > 0.01f && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            animator.SetBool("IsWalking", true);
        }
        else animator.SetBool("IsWalking", false);

    }
}
