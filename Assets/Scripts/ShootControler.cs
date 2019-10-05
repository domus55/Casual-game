using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControler : MonoBehaviour {

    public float dmg = 1;
    
    ShootMove move;
    AudioSource audioSource;
    bool stop = false;
    float time = 0;

    void Start () {
        move = GetComponent<ShootMove>();
        audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {

        time += Time.deltaTime;

        if (stop)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            move.Move();
        }

        if (time > 10) Destroy(gameObject);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( !stop && collision.gameObject.tag != "Player" && collision.gameObject.tag != "Weapon")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Hp>().Hited(dmg);
                //var main = GetComponent<ParticleSystem>().main;
                //main.startColor = new Color(255, 0, 0);
            }
            else
            {
                GetComponent<ParticleSystem>().Play(false);
                audioSource.Play();
            }

            
            stop = true;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 5);
        }

    }
}
