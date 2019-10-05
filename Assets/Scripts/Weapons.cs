using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour {

    public Joystick joystick;
    public GameObject Bullet;

    [HideInInspector]
    public bool shootedNow = false;
    [HideInInspector]
    public bool wantToShoot = false;
    [HideInInspector]
    public int activeWeapon = 1;
    [HideInInspector]
    public float shootDelay = 0.5f;
    [HideInInspector]
    public float dmg = 1;
    public float dmgMultiply = 1;

    bool pistol = false;
    bool shotgun = false;
    bool ak47 = false;
    bool p90 = false;

    int pistolAmmo = 0;
    int shotgunAmmo = 0;
    int ak47Ammo = 0;
    int p90Ammo = 0;

    Animator animator;
    Transform tr;
    SpriteRenderer render;
    Text ammo;
    float time = 0;

	void Start () {
        GameObject.Find("Pistol").GetComponent<WeaponSetActive>().Active(false);
        GameObject.Find("Shotgun").GetComponent<WeaponSetActive>().Active(false);
        GameObject.Find("Ak47").GetComponent<WeaponSetActive>().Active(false);
        GameObject.Find("P90").GetComponent<WeaponSetActive>().Active(false);
        ammo = GameObject.Find("Ammo").GetComponent<Text>();
        animator = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        render = GetComponent<SpriteRenderer>();

        ammo.text = "Ammo: " + pistolAmmo.ToString();
    }
	
	void Update () {
        shootedNow = false;
        time += Time.deltaTime;
        ChangeWeapon();

        int ammunition = 1;
        switch(activeWeapon)
        {
            case 1: ammunition = pistolAmmo; break;
            case 2: ammunition = shotgunAmmo; break;
            case 3: ammunition = ak47Ammo; break;
            case 4: ammunition = p90Ammo; break;
        }

        if ((Input.GetKey(KeyCode.Space) || wantToShoot) && time >= shootDelay && ammunition > 0)
        {
            shootedNow = true;

            int side = 1;
            if (!render.flipX) side = -1;

            if(activeWeapon == 2)
            {
                GameObject.Find("Main Camera").GetComponent<MoveCamera>().ShakeCamera(2, 0.2f);
                GameObject[] bullet = new GameObject[5];

                for(int i = 0; i<5; i++)
                {
                    float a = Random.Range(-100, 100);

                    bullet[i] = Instantiate(Bullet, new Vector3(tr.position.x - (0.32f * side), tr.position.y + 0.16f, tr.position.z), Quaternion.identity);
                    bullet[i].GetComponent<ShootMove>().right = !render.flipX;

                    bullet[i].GetComponent<ShootControler>().dmg = dmgMultiply * dmg;
                    bullet[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(a, a/2));
                }
            }
            else
            {
                GameObject bullet;

                bullet = Instantiate(Bullet, new Vector3(tr.position.x - (0.32f * side), tr.position.y + 0.16f, tr.position.z), Quaternion.identity);
                bullet.GetComponent<ShootMove>().right = !render.flipX;

                bullet.GetComponent<ShootControler>().dmg = dmgMultiply * dmg;

                float a = Random.Range(-100, 100);

                if (activeWeapon == 1) a /= 10;
                if (activeWeapon == 3) a /= 4;
                if (activeWeapon == 4) a /= 2;

                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(a, a / 2));

            }

            if(activeWeapon == 1)
            {
                pistolAmmo--;
                ammo.text = "Ammo: " + pistolAmmo.ToString();

                if (pistolAmmo <= 0)
                {
                    pistol = false;
                    GameObject.Find("Pistol").GetComponent<WeaponSetActive>().Active(false);
                }
            }

            if (activeWeapon == 2)
            {
                shotgunAmmo--;
                ammo.text = "Ammo: " + shotgunAmmo.ToString();

                if (shotgunAmmo <= 0)
                {
                    shotgun = false;
                    GameObject.Find("Shotgun").GetComponent<WeaponSetActive>().Active(false);
                }
            }

            if (activeWeapon == 3)
            {
                ak47Ammo--;
                ammo.text = "Ammo: " + ak47Ammo.ToString();

                if (ak47Ammo <= 0)
                {
                    ak47 = false;
                    GameObject.Find("Ak47").GetComponent<WeaponSetActive>().Active(false);
                }
            }

            if (activeWeapon == 4)
            {
                p90Ammo--;
                ammo.text = "Ammo: " + p90Ammo.ToString();

                if (p90Ammo <= 0)
                {
                    p90 = false;
                    GameObject.Find("P90").GetComponent<WeaponSetActive>().Active(false);
                }
            }

            time = 0;
        }
    }

    public void ChangeWeapon(int a = -1)
    {

        if((Input.GetKeyDown(KeyCode.Alpha1) || a == 1) && pistol)
        {
            animator.SetInteger("ActiveWeapon", 1);
            ammo.text = "Ammo: " + pistolAmmo.ToString();
            activeWeapon = 1;
            shootDelay = 0.5f;
            dmg = 1;
        }

        if ((Input.GetKeyDown(KeyCode.Alpha2) || a == 2) && shotgun)
        {
            animator.SetInteger("ActiveWeapon", 2);
            ammo.text = "Ammo: " + shotgunAmmo.ToString();
            activeWeapon = 2;
            shootDelay = 1f;
            dmg = 1;
            time = 500;
        }

        if ((Input.GetKeyDown(KeyCode.Alpha3) || a == 3) && ak47)
        {
            animator.SetInteger("ActiveWeapon", 3);
            ammo.text = "Ammo: " + ak47Ammo.ToString();
            activeWeapon = 3;
            shootDelay = 0.15f;
            dmg = 0.8f;
        }

        if ((Input.GetKeyDown(KeyCode.Alpha4) || a == 4) && p90)
        {
            animator.SetInteger("ActiveWeapon", 4);
            ammo.text = "Ammo: " + p90Ammo.ToString();
            activeWeapon = 4;
            shootDelay = 0.1f;
            dmg = 0.5f;
        }
    }

    public void AddWeapon(int name, int ammoAmount=0)
    {
        if(ammoAmount==0) // default amounts
        {
            switch(name)
            {
                case 1:
                    pistolAmmo += 10;
                    break;

                case 2:
                    shotgunAmmo += 3;
                    break;

                case 3:
                    ak47Ammo += 10;
                    break;

                case 4:
                    p90Ammo += 15;
                    break;

                default:
                    break;
            }
        } else { // custom amounts
            switch (name)
            {
                case 1:
                    pistolAmmo += ammoAmount;
                    break;

                case 2:
                    shotgunAmmo += ammoAmount;
                    break;

                case 3:
                    ak47Ammo += ammoAmount;
                    break;

                case 4:
                    p90Ammo += ammoAmount;
                    break;

                default:
                    break;
            }
        }
        if (name == 1)
        {
            GameObject.Find("Pistol").GetComponent<WeaponSetActive>().Active(true);
            pistol = true;
            if(activeWeapon == 1) ammo.text = "Ammo: " + pistolAmmo.ToString();

            if (activeWeapon == 2 && shotgunAmmo == 0) ChangeWeapon(1);
            if (activeWeapon == 3 && ak47Ammo == 0) ChangeWeapon(1);
            if (activeWeapon == 4 && p90Ammo == 0) ChangeWeapon(1);
        }

        if (name == 2)
        {
            GameObject.Find("Shotgun").GetComponent<WeaponSetActive>().Active(true);
            shotgun = true;
            if (activeWeapon == 2) ammo.text = "Ammo: " + shotgunAmmo.ToString();

            if (activeWeapon == 1 && pistolAmmo == 0) ChangeWeapon(2);
            if (activeWeapon == 3 && ak47Ammo == 0) ChangeWeapon(2);
            if (activeWeapon == 4 && p90Ammo == 0) ChangeWeapon(2);
        }

        if (name == 3)
        {
            GameObject.Find("Ak47").GetComponent<WeaponSetActive>().Active(true);
            ak47 = true;
            if (activeWeapon == 3) ammo.text = "Ammo: " + ak47Ammo.ToString();

            if (activeWeapon == 1 && pistolAmmo == 0) ChangeWeapon(3);
            if (activeWeapon == 2 && shotgunAmmo == 0) ChangeWeapon(3);
            if (activeWeapon == 4 && p90Ammo == 0) ChangeWeapon(3);
        }

        if (name == 4)
        {
            GameObject.Find("P90").GetComponent<WeaponSetActive>().Active(true);
            p90 = true;
            if (activeWeapon == 4) ammo.text = "Ammo: " + p90Ammo.ToString();

            if (activeWeapon == 1 && pistolAmmo == 0) ChangeWeapon(4);
            if (activeWeapon == 2 && shotgunAmmo == 0) ChangeWeapon(4);
            if (activeWeapon == 3 && ak47Ammo == 0) ChangeWeapon(4);
        }
    }

    public void ButtonIsClick(bool isClick)
    {
        if (isClick) wantToShoot = true;
        else wantToShoot = false;
    }

    public void SaveWeapon()
    {
        WeaponClass weapon = new WeaponClass();

        weapon.activeWeapon = activeWeapon;
        weapon.shootDelay = shootDelay;
        weapon.dmg = dmg;
        weapon.dmgMultiply = dmgMultiply;

        weapon.pistol  = pistol;
        weapon.shotgun = shotgun;
        weapon.ak47    = ak47;
        weapon.p90     = p90;

        weapon.pistolAmmo  = pistolAmmo;
        weapon.shotgunAmmo = shotgunAmmo;
        weapon.ak47Ammo    = ak47Ammo;
        weapon.p90Ammo     = p90Ammo;

        PlayerStats.weapon = weapon;
    }

    public void LoadWeapon()
    {
        /*WeaponClass weapon = PlayerStats.weapon;
        activeWeapon = weapon.activeWeapon;
        shootDelay = weapon.shootDelay;
        dmg = weapon.dmg;
        dmgMultiply = weapon.dmgMultiply;

        pistol = weapon.pistol;
        shotgun = weapon.shotgun;
        ak47 = weapon.ak47;
        p90 = weapon.p90;

        pistolAmmo = weapon.pistolAmmo;
        shotgunAmmo = weapon.shotgunAmmo;
        ak47Ammo = weapon.ak47Ammo;
        p90Ammo = weapon.p90Ammo;

        animator.SetInteger("ActiveWeapon", activeWeapon);
        if (pistol)
        {
            ammo.text = "Ammo: " + pistolAmmo;
        }
        if (shotgun)
        {
            ammo.text = "Ammo: " + shotgunAmmo;
        }
        if (ak47)
        {
            ammo.text = "Ammo: " + ak47Ammo;
        }
        if (p90)
        {
            ammo.text = "Ammo: " + p90Ammo;
        }

        if (pistol) GameObject.Find("Pistol").GetComponent<WeaponSetActive>().Active(true);
        if (shotgun) GameObject.Find("Shotgun").GetComponent<WeaponSetActive>().Active(true);
        if (ak47) GameObject.Find("Ak47").GetComponent<WeaponSetActive>().Active(true);
        if (p90) GameObject.Find("P90").GetComponent<WeaponSetActive>().Active(true);*/
    }
}
