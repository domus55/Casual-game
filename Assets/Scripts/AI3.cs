using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI3 : MonoBehaviour {

    public float distance = 10;
    public float speed = 1;

    Rigidbody2D rb;
    Transform player;
    Transform position;
    bool up;
    bool left;
    bool down;
    bool right;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        position = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        up = false;
        left = false;
        down = false;
        right = false;

        if (Utils.distance(player.position, transform.position) <= distance)
        {

            if (player.position.x - 0.2f > position.position.x)
            {
                right = true;
            }
            else
            {
                if (player.position.x < position.position.x - 0.2f)
                {
                    left = true;

                }
            }

            if (player.position.y - 0.2f > position.position.y)
            {
                up = true;
            }
            else
            {
                if (player.position.y < position.position.y - 0.2f)
                {
                    down = true;
                }
            }
        }

        rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y * 0.9f);

        rb.velocity = new Vector2(0,0);

        if (right && !left)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if (left && !right)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        if (up && !down)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }

        if (down && !up)
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
        }

        GetComponent<EnemyInfo>().isGrounded = false;
    }
}
