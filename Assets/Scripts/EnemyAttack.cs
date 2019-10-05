using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float dmg = 1;
    public float attackDelay = 1;

    float time = 0;

    private void Update()
    {
        time += Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (time >= attackDelay)
        {
            GameObject collider = collision.gameObject;

            if (collider.tag == "Player")
            {
                collider.GetComponent<Hp>().Hited(dmg);

                time = 0;
            }
        }
    }
}
