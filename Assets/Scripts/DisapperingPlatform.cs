using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapperingPlatform : MonoBehaviour {

    public float duration = 0.5f;
    public float invisibleDuration = 1;

    SpriteRenderer render;
    BoxCollider2D colision;
    float time;
    float a = 1;
    float remainingInvisibleTime;
    bool isTouching = false;

    void Start () {
        render = GetComponent<SpriteRenderer>();
        colision = GetComponent<BoxCollider2D>();
	}
	

	void Update () {
        if (Time.time - time < 0.1f) isTouching = true;
        else isTouching = false;

        remainingInvisibleTime -= Time.deltaTime;

        if(remainingInvisibleTime < 0)
        {
            if (isTouching)
            {
                a -= Time.deltaTime / duration;
                render.color = new Color(1, 1, 1, a);
            }
            else
            {
                a += Time.deltaTime / duration;
                render.color = new Color(1, 1, 1, a);
            }

            if (a > 1) a = 1;
            if (a < 0) a = 0;

            if (a == 0)
            {
                remainingInvisibleTime = invisibleDuration;
                colision.enabled = false;
            }
            else colision.enabled = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.tag == "Enemy")
        {
            time = Time.time;
            collision.gameObject.transform.position = new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + 0.005f);
        }
        
    }
}
