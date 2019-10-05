using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsTouching : MonoBehaviour {

    public bool isTouching = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isTouching = true;
        }
            
    }
}
