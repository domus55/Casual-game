using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStone : MonoBehaviour {

    public float speed = 2;

    float time = 0;
	
	// Update is called once per frame

	void Update () {

        transform.position += transform.up * Time.deltaTime * speed;

        time += Time.deltaTime;
        if (time > 40) Destroy(gameObject);
    }
}
