using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponClass
{
    public int activeWeapon;
    public float shootDelay;
    public float dmg;
    public float dmgMultiply;

    public bool pistol;
    public bool shotgun;
    public bool ak47;
    public bool p90;

    public int pistolAmmo;
    public int shotgunAmmo;
    public int ak47Ammo;
    public int p90Ammo;
}

public static class PlayerStats
{
    private static WeaponClass Weapon;
    private static bool Update;

    public static WeaponClass weapon
    {
        get 
        {
            return Weapon;
        }
        set 
        {
            Weapon = value;
        }
    }

    public static bool update
    {
        get
        {
            return Update;
        }
        set
        {
            Update = value;
        }
    }
}