using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerHp : MonoBehaviour {

    GameObject Player;
    float procent = 1;
    float startWidth = 0;
    float height = 0;
    float posX = 0;
    float posY = 0;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        startWidth = GetComponent<RectTransform>().transform.localScale.x;
        height = GetComponent<RectTransform>().transform.localScale.y;
        posX = GetComponent<RectTransform>().transform.position.x;
        posY = GetComponent<RectTransform>().transform.position.y;
    }
	
	void Update ()
    {
        procent = Player.GetComponent<Hp>().hp / Player.GetComponent<Hp>().MaxHp;
        if (procent < 0) procent = 0;
        GetComponent<RectTransform>().transform.localScale = new Vector2(startWidth * procent, height);

        if(Screen.width == 1280)
        {
            GetComponent<RectTransform>().transform.position = new Vector2((posX - 195 * (startWidth - GetComponent<RectTransform>().transform.localScale.x)), posY);
        }
        else
        {
            if(Screen.width == 2340)
            {
                GetComponent<RectTransform>().transform.position = new Vector2((posX - 292 * (startWidth - GetComponent<RectTransform>().transform.localScale.x)), posY);
            }
            else
            {
                if(Screen.width == 1920)
                {
                    GetComponent<RectTransform>().transform.position = new Vector2((posX - 292 * (startWidth - GetComponent<RectTransform>().transform.localScale.x)), posY);
                }
                else
                {
                    GetComponent<RectTransform>().transform.position = new Vector2(posX, posY);
                }
                    
            }
        }
    }
}
