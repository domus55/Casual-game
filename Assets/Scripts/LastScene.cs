using UnityEngine.UI;
using UnityEngine;

public class LastScene : MonoBehaviour
{

    Text text1;
    Text text2;
    GameObject exit;

    float color1 = 0;
    float color2 = 0;
    float color3 = 0;

    float time = 0;

    void Start()
    {
        text1 = GameObject.Find("Text1").GetComponent<Text>();
        text2 = GameObject.Find("Text2").GetComponent<Text>();
        exit = GameObject.Find("Exit");
        exit.SetActive(false);
    }

    
    void Update()
    {
        time += Time.deltaTime;

        if(time > 1)
        {
            if(time < 3)
            {
                color1 += Time.deltaTime * 0.5f;
                text1.color = new Color(1, 1, 1, color1);
            }
            if(time > 4 && time < 6)
            {
                color1 -= Time.deltaTime * 0.5f;
                text1.color = new Color(1, 1, 1, color1);
            }
            if (time > 6 && time < 8)
            {
                color2 += Time.deltaTime * 0.5f;
                text2.color = new Color(1, 1, 1, color2);
            }
            if(time > 8)
            {
                if(!exit.activeSelf) exit.SetActive(true);
                color3 += Time.deltaTime * 0.5f;
                exit.GetComponent<Image>().color = new Color(1, 1, 1, color3);
            }
        }
    }
}
