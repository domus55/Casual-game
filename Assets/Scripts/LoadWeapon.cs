using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWeapon : MonoBehaviour {

    float time;
    bool a = true;

	void Update () {

        if(a) { time = Time.time; a = false; }

        if (PlayerStats.update == true && Time.time - time < 1)
        {
            //GameObject.Find("Player").GetComponent<Weapons>().LoadWeapon();
            PlayerStats.update = false;
        }
    }

}
