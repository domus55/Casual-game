using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowParticle : MonoBehaviour {

    public int particleNumber = 10;

    ParticleSystem particle;
    Hp hp;
    bool isDead = false;
    float prevHp = 0;


    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        hp = GetComponent<Hp>();

    }

    void Update()
    {

        if (prevHp > hp.hp)
        {
            if (!isDead)
            {
                particle.Emit(particleNumber);
                if (hp.hp <= 0)
                {
                    particle.Emit(particleNumber * 2);
                    isDead = true;
                }
            }
        }

        prevHp = hp.hp;
    }
}
