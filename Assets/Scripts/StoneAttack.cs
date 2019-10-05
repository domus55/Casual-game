using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneAttack : MonoBehaviour {

    public float dmg = 1;
    public bool attackEnemies = true;

    bool stop = false;
    float color = 1;
    AudioSource audioSource;
    SpriteRenderer render;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        render = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(attackEnemies)
        {
            if (!stop && collision.gameObject.tag != "Weapon")
            {
                if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
                {
                    collision.gameObject.GetComponent<Hp>().Hited(dmg);
                }
                else
                {
                    GetComponent<ParticleSystem>().Play(false);
                    audioSource.Play();
                }



                stop = true;
                GetComponent<Collider2D>().enabled = false;
                Destroy(gameObject, 2);
            }
        }
        else
        {
            if (!stop && collision.gameObject.tag != "Weapon" && collision.gameObject.tag != "Enemy")
            {
                if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
                {
                    collision.gameObject.GetComponent<Hp>().Hited(dmg);
                }
                else
                {
                    GetComponent<ParticleSystem>().Play(false);
                    audioSource.Play();
                }



                stop = true;
                GetComponent<Collider2D>().enabled = false;
                Destroy(gameObject, 2);
            }
        }

        
    }

    private void Update()
    {
        if(stop)
        {
            color -= Time.deltaTime * 6;
            if (color < 0) color = 0;
            render.color = new Color(1, 1, 1, color);
        }
    }
}
