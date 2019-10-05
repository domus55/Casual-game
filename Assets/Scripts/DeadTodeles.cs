using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadTodeles : MonoBehaviour
{
    Hp hp;
    ParticleSystem particle;
    GameObject lastScene;
    float color = 0;
    float time = 0;
    float totalTime = 0;
    bool play = false;

    void Start()
    {
        hp = gameObject.GetComponent<Hp>();
        particle = gameObject.GetComponent<ParticleSystem>();
        lastScene = GameObject.Find("LastScene");
        lastScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hp.hp <= 0 && !play)
        {
            //particle.Play(false);
            particle.Emit(100);
            play = true;
        }

        if(play)
        {
            time += Time.deltaTime;

            if(time >= 0.25f)
            {
                totalTime += time;
                time = 0;

                if(totalTime < 1)
                {
                    particle.Emit(100);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(totalTime > 1)
        {
            if(!lastScene.activeSelf) lastScene.SetActive(true);
            lastScene.GetComponent<Image>().color = new Color(1, 1, 1, color);
            color += Time.fixedDeltaTime * 0.3f;
            if (color > 1)
            {
                color = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
