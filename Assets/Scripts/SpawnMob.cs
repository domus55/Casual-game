using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMob : MonoBehaviour {

    public GameObject monster;
    public float delay = 5;
    public bool alwaysFollow = false;

    Transform tr;
    float time = 0;

	void Start () {
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if(time >= delay)
        {
            if(alwaysFollow)
            {
                GameObject enemy = Instantiate(monster, tr);
                if(enemy.GetComponent<AI1>() != null)
                {
                    enemy.GetComponent<AI1>().distance = 10000;
                }
                if (enemy.GetComponent<AI3>() != null)
                {
                    enemy.GetComponent<AI3>().distance = 10000;
                }
            }
            else
            {
                Instantiate(monster, tr);
            }
            
            time = 0;
        }
        
    }
}
