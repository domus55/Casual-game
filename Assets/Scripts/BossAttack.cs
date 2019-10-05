using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour {

    public GameObject stone;

    Transform player;
    float time = 0;
    float time2 = 0;
    float time3 = 0;
    int fireStones = 0;
    int counter = 0;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update () {
        time += Time.deltaTime;
        time2 += Time.deltaTime;

        if (((int)time / 10) % 3 == 1)
        {
            if (time2 >= 3)
            {
                if(fireStones == 1)
                {
                    for (int i = 0; i < 32; i++)
                    {
                        GameObject bullet = Instantiate(stone, transform.position, Quaternion.Euler(0, 0, i * 11.25f));
                        bullet.GetComponent<StoneAttack>().attackEnemies = false;

                    }
                }
                else
                {
                    for (int i = 0; i < 16; i++)
                    {
                        GameObject bullet = Instantiate(stone, transform.position, Quaternion.Euler(0, 0, i * 22.5f));
                        bullet.GetComponent<StoneAttack>().attackEnemies = false;
                    }
                }
                
                fireStones++;
                if(fireStones == 3) fireStones = 0;
                time2 = 0;
            }

            
        }
        if (((int)time / 10) % 3 == 2)
        {

            if (time2 >= 3)
            {
                Vector3 targetDir = player.position - transform.position;
                float angle = Vector2.Angle(targetDir, transform.up);
                if (transform.position.x < player.position.x) angle = -angle;

                for (int i = -1; i < 2; i++)
                {
                    GameObject bullet = Instantiate(stone, transform.position, Quaternion.Euler(0, 0, angle + i * 10));
                    bullet.GetComponent<StoneAttack>().attackEnemies = false;
                }
                


                time2 = 0;
            }
        }

        if (((int)time / 10) % 3 == 0)
        {

            if (time2 >= 2.5f)
            {
                time3 += Time.deltaTime;

                if(time3 > 0.25f)
                {
                    Vector3 targetDir = player.position - transform.position;
                    float angle = Vector2.Angle(targetDir, transform.up);
                    if (transform.position.x < player.position.x) angle = -angle;

                    for (int i = -1; i < 2; i++)
                    {
                        GameObject bullet = Instantiate(stone, transform.position, Quaternion.Euler(0, 0, angle));
                        bullet.GetComponent<StoneAttack>().attackEnemies = false;
                    }

                    counter++;
                    if (counter == 3)
                    {
                        counter = 0;
                        time2 = 0;
                    }
                    time3 = 0;
                }
            }
        }
    }
}
