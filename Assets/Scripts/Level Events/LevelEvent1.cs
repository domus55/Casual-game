using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEvent1 : MonoBehaviour {

    public float up = 0;
    public float down = 0;
    public float left = 0;
    public float right = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if (up != 0)
            {
                GameObject.Find("Main Camera").GetComponent<MoveCamera>().up = up;
            }
            if (down != 0)
            {
                GameObject.Find("Main Camera").GetComponent<MoveCamera>().down = down;
            }
            if (left != 0)
            {
                GameObject.Find("Main Camera").GetComponent<MoveCamera>().left = left;
            }
            if (right != 0)
            {
                GameObject.Find("Main Camera").GetComponent<MoveCamera>().right = right;
            }
        }
    }
}
