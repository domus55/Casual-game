using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour {

    public float MaxHp = 3;
    public float hp;

    bool isAlive = true;
    float color = 1;
	
	void Start ()
    {
        hp = MaxHp;
	}

    public void Add (float Hp)
    {
        hp += Hp;
        if (hp > MaxHp) hp = MaxHp;
    }
	
	public void Hited(float dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            if(gameObject.tag == "Player")
            {
                GetComponent<PlayerControler>().isDead = true;
                GameObject.Find("Main Camera").GetComponent<MoveCamera>().enabled = false;
            }
            else
            {
                if(gameObject.name == "Tofeles")
                {
                    isAlive = false;
                    gameObject.GetComponent<Collider2D>().enabled = false;
                    gameObject.GetComponent<ShowHp>().bar.SetActive(false);
                    gameObject.GetComponent<BossAttack>().enabled = false;
                    Destroy(gameObject, 10);
                    Destroy(GameObject.Find("Torch"), 0.5f);
                }
                else
                {
                    isAlive = false;
                    gameObject.GetComponent<Collider2D>().enabled = false;
                    gameObject.GetComponent<ShowHp>().bar.SetActive(false);
                    Destroy(gameObject, 1);
                }
            }
        }
    }

    private void Update()
    {
        if(!isAlive)
        {
            if (gameObject.name == "Tofeles")
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, color);
                color -= Time.deltaTime;
                if (color < 0) color = 0;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, color);
                color -= Time.deltaTime * 7;
                if (color < 0) color = 0;
            }  
        }
    }
}
