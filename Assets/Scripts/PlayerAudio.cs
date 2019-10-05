using UnityEngine.Audio;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    public AudioSource weaponAudioSource;
    public AudioSource jumpAudioSource;
    public AudioClip pistol;
    public AudioClip shotgun;
    
    Weapons weapon;
    PlayerMove jump;
    int prevWeapon = 1;
    

	void Start () {
        weapon = GetComponent<Weapons>();
        jump = GetComponent<PlayerMove>();

        weaponAudioSource.clip = pistol;
    }
	
	void Update () {

        if(prevWeapon != weapon.activeWeapon)
        {
            if (weapon.activeWeapon == 2)
            {
                weaponAudioSource.clip = shotgun;
            }
            else
            {
                weaponAudioSource.clip = pistol;
            }
        }

        if(weapon.shootedNow)
        {
            weaponAudioSource.Play();
        }

        if (jump.jumpNow) jumpAudioSource.Play();

        prevWeapon = weapon.activeWeapon;
    }
}
