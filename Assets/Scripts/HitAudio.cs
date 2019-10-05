using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAudio : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip hit;
    public AudioClip dead;
    
    Hp hp;
    bool isDead = false;
    float prevHp = 0;


    void Start () {
        if(gameObject.name != "Player") audioSource = GetComponent<AudioSource>();
        hp = GetComponent<Hp>();
        audioSource.clip = hit;
	}
	
	void Update () {
		
        if(prevHp > hp.hp)
        {
            if(hp.hp <= 0)
            {
                audioSource.clip = dead;
            }
            if(!isDead)
            {
                audioSource.Play();
                if (hp.hp <= 0) isDead = true;
            }
            
        }

        prevHp = hp.hp;
    }
}
