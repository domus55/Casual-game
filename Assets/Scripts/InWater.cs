using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWater : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.tag == "Player")
        {
            collider.GetComponent<PlayerMove>().inWater = true;
        }

        if (collider.tag == "Enemy")
        {
            collider.GetComponent<EnemyInfo>().inWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.tag == "Player")
        {
            collider.GetComponent<PlayerMove>().inWater = false;
        }

        if (collider.tag == "Enemy")
        {
            collider.GetComponent<EnemyInfo>().inWater = false;
        }
    }

}
