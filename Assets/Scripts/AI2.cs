using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI2 : MonoBehaviour {

    Rigidbody2D rb;
    Transform position;

    public float speed = 1;
    public float distance = 4;

    bool left;
    bool right;
    float startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        position = GetComponent<Transform>();

        startPosition = position.position.x;

        if (distance >= 0) right = true;
        else left = true;
    }

    void Update()
    {

        if(distance > 0)
        {
            if(right)
            {
                if(position.position.x >= startPosition + distance) { right = false; left = true; }
            }
            else
            {
                if(position.position.x <= startPosition) { right = true; left = false; }
            }
        }
        else
        {
            if(right)
            {
                if(position.position.x >= startPosition) { right = false; left = true; }
            }
            else
            {
                if (position.position.x <= startPosition + distance) { right = true; left = false; }
            }
        }

        if (right && !left)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if (left && !right)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }
}
