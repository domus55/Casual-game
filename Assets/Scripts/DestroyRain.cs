using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRain : MonoBehaviour
{
    float time = 0;
    float color = 1;
    bool hitGround = false;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 10) Destroy(gameObject);
        if(hitGround)
        {
            color -= Time.deltaTime * 2;
            if (color < 0) color = 0;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, color);
            if (time > 2) Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        time = 0;
        GetComponent<ParticleSystem>().Play(false);
        hitGround = true;
    }
}
