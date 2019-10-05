using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTexture : MonoBehaviour {

    BoxCollider2D[] playerCollider = new BoxCollider2D[2];
    PlayerMove player;
    SpriteRenderer render;
    Rigidbody2D rb;

    bool thisIsPlayer = false;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        if (gameObject.tag == "Player")
        {
            thisIsPlayer = true;
            player = gameObject.GetComponent<PlayerMove>();
        }
        playerCollider = gameObject.GetComponents<BoxCollider2D>();

        
    }

    void Update () {

        if(thisIsPlayer)
        {
            if (Input.GetKey(KeyCode.A) || player.left)
            {
                render.flipX = true;

                if (playerCollider[0].size == new Vector2(0.45f, 0.95f))
                {
                    playerCollider[0].offset = new Vector2(0.08f, -0.005f);
                    playerCollider[1].offset = new Vector2(0.09f, -0.5f);
                }
                else
                {
                    playerCollider[0].offset = new Vector2(0.09f, -0.5f);
                    playerCollider[1].offset = new Vector2(0.08f, -0.005f);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.D) || player.right)
                {
                    render.flipX = false;
                    if(playerCollider[0].size == new Vector2(0.45f, 0.95f))
                    {
                        playerCollider[0].offset = new Vector2(-0.08f, -0.005f);
                        playerCollider[1].offset = new Vector2(-0.09f, -0.5f);
                    }
                    else
                    {
                        playerCollider[0].offset = new Vector2(-0.09f, -0.5f);
                        playerCollider[1].offset = new Vector2(-0.08f, -0.005f);
                    }
                    
                }
                /*else
                {
                    if (rb.velocity.x < 0)
                    {
                        render.flipX = true;

                        if (playerCollider[0].size == new Vector2(0.45f, 0.95f))
                        {
                            playerCollider[0].offset = new Vector2(0.08f, -0.005f);
                            playerCollider[1].offset = new Vector2(0.09f, -0.5f);
                        }
                        else
                        {
                            playerCollider[0].offset = new Vector2(0.09f, -0.5f);
                            playerCollider[1].offset = new Vector2(0.08f, -0.005f);
                        }
                    }
                    else
                    {
                        if (rb.velocity.x > 0)
                        {
                            render.flipX = false;

                            if (playerCollider[0].size == new Vector2(0.45f, 0.95f))
                            {
                                playerCollider[0].offset = new Vector2(-0.08f, -0.005f);
                                playerCollider[1].offset = new Vector2(-0.09f, -0.5f);
                            }
                            else
                            {
                                playerCollider[0].offset = new Vector2(-0.09f, -0.5f);
                                playerCollider[1].offset = new Vector2(-0.08f, -0.005f);
                            }
                        }
                    }
                }*/
            }
                
        }
        else
        {
            if (rb.velocity.x < 0)
            {
                render.flipX = true;
            }
            else
            {
                if (rb.velocity.x > 0)
                {
                    render.flipX = false;
                }
            }
        }
	}
}
