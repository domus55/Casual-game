using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour {

    public Vector2 speed;
    public Vector2 distance;

    Vector2 startPosition;
    Vector2 speed2;
    bool right = true;

    void Start () {
        startPosition = transform.position;
        speed2 = speed;

        distance /= 2;
    }
	
	void Update () {
        Vector2 v = transform.position;

        if (speed2.x >= 0)
        {
            if (speed2.y >= 0)
            {
                if (v.x < startPosition.x || v.y < startPosition.y) right = true;
                if (v.x > startPosition.x + distance.x || v.y > startPosition.y + distance.y) right = false;
            }
            else
            {
                if (v.x < startPosition.x || v.y > startPosition.y) right = true;
                if (v.x > startPosition.x + distance.x || v.y < startPosition.y - distance.y) right = false;
            }
        }
        else
        {
            if (speed2.y >= 0)
            {
                if (v.x > startPosition.x || v.y < startPosition.y) right = true;
                if (v.x < startPosition.x - distance.x || v.y > startPosition.y + distance.y) right = false;
            }
            else
            {
                if (v.x > startPosition.x || v.y > startPosition.y) right = true;
                if (v.x < startPosition.x - distance.x || v.y < startPosition.y - distance.y) right = false;
            }

        }

        if (right) speed = speed2;
        else speed = -speed2;

        transform.position = new Vector2(transform.position.x + (speed.x * Time.deltaTime), transform.position.y + (speed.y * Time.deltaTime));
    }
}
