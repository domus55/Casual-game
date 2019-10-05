using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI1 : MonoBehaviour {

    public float distance = 10;
    public float speed = 1;
    public float jumpForce = 300;
    public float jumpCooldown = 2;
    private float jumpCooldownLeft = 0;

    Rigidbody2D Rb;
    Transform player;
    Transform position;
    bool up;
    bool left;
    bool down;
    bool right;

    void Start ()
    {
        Rb = GetComponent<Rigidbody2D>();
        position = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	
	void Update ()
    {
        jumpCooldownLeft-=Time.deltaTime;

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

            if (GetComponent<EnemyInfo>().inWater)
            {
                if (player.position.y > position.position.y)
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
            else
            {
                if (player.position.y - 0.5f > position.position.y) // TODO: skok tylko przy horyzontalnej kolizji z blokiem (usunąć stary warunek)
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
        }

        Rb.velocity = new Vector2(Rb.velocity.x * 0.9f, Rb.velocity.y);

        if (GetComponent<EnemyInfo>().inWater)
        {
            if (right && !left)
            {
                Rb.velocity = new Vector2(speed / 2, Rb.velocity.y);
            }

            if (left && !right)
            {
                Rb.velocity = new Vector2(-speed / 2, Rb.velocity.y);
            }

            if (up && !down)
            {
                Rb.velocity = new Vector2(Rb.velocity.x, speed);
            }

            if (down && !up)
            {
                Rb.velocity = new Vector2(Rb.velocity.x, -speed / 2);
            }

            if(!up && !down)
            {
                Rb.velocity = new Vector2(Rb.velocity.x, -0.4f);
            }
        }
        else
        {
            if (right && !left)
            {
                Rb.velocity = new Vector2(speed, Rb.velocity.y);
            }

            if (left && !right)
            {
                Rb.velocity = new Vector2(-speed, Rb.velocity.y);
            }

            if(up && Mathf.Abs(Rb.velocity.y) < 0.001f && GetComponent<EnemyInfo>().isGrounded && jumpCooldownLeft <= 0)
            {
                Rb.AddForce(new Vector2(Rb.velocity.x, jumpForce));
                jumpCooldownLeft = jumpCooldown;
            }
        }
    }
}
