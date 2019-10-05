using UnityEngine.UI;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public GameObject youDied;
    public bool isDead = false;

    bool firstTime = true;
    float x = 1;
    float diedColor = 1;

    private void Start()
    {
        youDied = GameObject.Find("YouDiedImage");
        youDied.SetActive(false);
    }



    private void Update()
    {
        if (isDead)
        {
            if(firstTime)
            {
                GetComponent<ParticleSystem>().Play(false);
                GetComponent<PlayerMove>().enabled = false;
                youDied.SetActive(true);
                Invoke("Restart", 1);
                
                firstTime = false;
            }

            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, x);
            
            x -= Time.deltaTime * 10;
            if (x < 0) x = 0;

            diedColor -= Time.deltaTime;
            if (diedColor < 0) diedColor = 0;

            youDied.GetComponent<Image>().color = new Color(diedColor, diedColor, diedColor);
        }
    }

    void Restart()
    {
        GameObject.Find("GameManager").GetComponent<MenuControl>().Restart();
    }
}
