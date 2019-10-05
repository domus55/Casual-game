using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFinish : MonoBehaviour {

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); 
        if (spriteRenderer != null) spriteRenderer.color = new Color(1, 1, 1, 0); // invisible finish
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<Weapons>().SaveWeapon();
            PlayerStats.update = true;

            int i = SceneManager.GetActiveScene().buildIndex + 1;
            int maxLvl = PlayerPrefs.GetInt("Level", 1);
            if (maxLvl < i)
            {
                PlayerPrefs.SetInt("Level", i);
            }

            SceneManager.LoadScene(i);
        }
    }
}
