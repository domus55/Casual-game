using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{


    public Rigidbody2D rb;
    public float speed = 5;
    public float jumpForce = 3;
    private bool android;
    [HideInInspector]
    public bool inWater = false;
    [HideInInspector]
    public bool jumpNow = false;
    [HideInInspector]
    public bool up;
    [HideInInspector]
    public bool down;
    // [HideInInspector]
    public bool left;
    [HideInInspector]
    public bool right;

    Animator animator;
    Joystick joystick;
    GameObject joystickHandle;
    GameObject buttonUp;
    GameObject buttonDown;
    GameObject buttonLeft;
    GameObject buttonRight;
    bool isGrounded = false;
    bool tryJump = false;
    bool jump = false;
    float prevInWaterTime;
    float prevOutsideWaterTime = -100;
    float lastBlockTouchTime;
    float blockMove;
    float blockMove2;
    float time = 0;
    float moveX = 0;
    float moveY = 0;
    float color = 0;
    bool goRight;
    bool goLeft;


    private void Start()
    {
        animator = GetComponent<Animator>();

        buttonUp = GameObject.Find("ButtonUp");
        buttonDown = GameObject.Find("ButtonDown");
        buttonLeft = GameObject.Find("ButtonLeft");
        buttonRight = GameObject.Find("ButtonRight");

        android = Application.platform == RuntimePlatform.Android;

        if (!android)
        {
            GameObject.Find("ButtonUp").SetActive(false);
            GameObject.Find("ButtonDown").SetActive(false);
            GameObject.Find("ButtonLeft").SetActive(false);
            GameObject.Find("ButtonRight").SetActive(false);
            GameObject.Find("ShootButton").SetActive(false);
            GameObject.Find("ShootImage").SetActive(false);
            GameObject.Find("PauseButton").SetActive(false);
        }
    }

    private void Update()
    {

        if (android) SetDownButtonEnable();

        if (Time.time - time < 0.05f || (rb.velocity.x == 0 && rb.velocity.y == 0 && !tryJump)) isGrounded = true;
        else isGrounded = false;

        if (Time.time - lastBlockTouchTime < 0.1f) blockMove = blockMove2;
        else blockMove = 0;

        jumpNow = false;
        if (Input.GetKey(KeyCode.W) || up) tryJump = true;
        else tryJump = false;

        if (inWater)
        {
            if (android)
            {
                if (Mathf.Abs(moveX) > speed / 2) moveX *= 0.7f;

                if (right && !left)
                {
                    if (moveX < speed / 2)
                        moveX += speed / 100f;
                }
                else
                {
                    if (left && !right)
                    {
                        if (moveX > -speed / 2)
                            moveX -= speed / 100f;
                    }
                    else
                    {
                        moveX *= 0.9f;
                    }
                }

                if (up && !down)
                {
                    if (moveY < speed / 1.5)
                        moveY += speed / 100f;
                }
                else
                {
                    if (down && !up)
                    {
                        if (moveY > -speed / 2)
                            moveY -= speed / 100f;
                    }
                    else
                    {
                        if (moveY > 0.15f)
                            moveY -= 0.001f;
                        moveY *= 0.9f;
                    }
                }
            }
            else
            {
                moveX = Input.GetAxis("Horizontal") * speed / 1.5f;
                moveY = Input.GetAxis("Vertical") * speed / 1.5f;
            }

            animator.SetBool("IsRunning", false);
        }
        else
        {
            if (right && !left)
            {
                moveX = speed;
            }
            else
            {
                if (left && !right)
                {
                    moveX = -speed;
                }
                else
                {
                    if (!left && !right)
                    {
                        moveX = Input.GetAxis("Horizontal") * speed;
                    }
                }
            }

            if (tryJump && isGrounded && Math.Abs(rb.velocity.y) < 0.05f) { jump = true; jumpNow = true; }

            if (Mathf.Abs(moveX) > 0.01 && isGrounded && Math.Abs(rb.velocity.y) < 0.01) animator.SetBool("IsRunning", true);
            else
            {
                animator.SetBool("IsRunning", false);
            }
        }
    }

    private void FixedUpdate()
    {
        if (inWater)
        {
            rb.velocity = new Vector2(moveX, moveY - 0.4f);
        }
        else
        {
            rb.velocity = new Vector2(moveX + blockMove, rb.velocity.y);
            if (jump)
            {
                rb.AddForce(new Vector2(0, jumpForce));
                jump = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Background")
        {
            time = Time.time;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BlockMove>() != null)
        {
            blockMove2 = collision.gameObject.GetComponent<BlockMove>().speed.x;
            lastBlockTouchTime = Time.time;
        }
    }

    private void SetDownButtonEnable()
    {

        if (Time.time - prevInWaterTime > 0.3f)
        {
            buttonDown.GetComponent<Image>().color = new Color(1, 1, 1, color);

            color -= Time.deltaTime * 5;
            if (color < 0) color = 0;
            if (color == 0) buttonDown.SetActive(false);
        }

        if (Time.time - prevOutsideWaterTime > 0.3f)
        {
            buttonDown.GetComponent<Image>().color = new Color(1, 1, 1, color);

            color += Time.deltaTime * 5;
            if (color > 1) color = 1;
            buttonDown.SetActive(true);
        }

        if (inWater)
        {
            prevInWaterTime = Time.time;
        }
        else
        {
            prevOutsideWaterTime = Time.time;
        }
    }

    public void ButtonUp(bool active)
    {
        if (active) up = true;
        else up = false;
    }

    public void ButtonDown(bool active)
    {
        if (active) down = true;
        else down = false;
    }

    public void ButtonLeft(bool active)
    {
        if (active) left = true;
        else left = false;
    }

    public void ButtonRight(bool active)
    {
        if (active) right = true;
        else right = false;
    }
}
