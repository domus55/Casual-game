using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour {

	public bool inWater = false;
    public bool isGrounded = false;

    float time;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Background")
        time = Time.time;
    }

    private void Update()
    {
        if (Time.time - time < 0.01f ) isGrounded = true;
        else isGrounded = false;
    }
}
