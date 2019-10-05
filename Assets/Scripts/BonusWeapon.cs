using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusWeapon : MonoBehaviour {

    public int weaponNumber = 1;
    [Tooltip("0 equals default amount of ammo for each weapon")]
    public int ammo = 0;

    bool destroied = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !destroied)
        {
            collision.gameObject.GetComponent<Weapons>().AddWeapon(weaponNumber, ammo);
            destroied = true;
            Destroy(gameObject);
        }
    }
}
