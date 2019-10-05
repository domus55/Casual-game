using UnityEngine;
using UnityEngine.UI;

public class ColorLevelButton : MonoBehaviour {

	void Start () {
        int actualLevel = 0;
        int maxLevel = PlayerPrefs.GetInt("Level", 1);
        if (gameObject.name == "Level1") actualLevel = 1;
        if (gameObject.name == "Level2") actualLevel = 2;
        if (gameObject.name == "Level3") actualLevel = 3;
        if (gameObject.name == "Level4") actualLevel = 4;
        if (gameObject.name == "Level5") actualLevel = 5;

        if (gameObject.name == "Level6") actualLevel = 6;
        if (gameObject.name == "Level7") actualLevel = 7;
        if (gameObject.name == "Level8") actualLevel = 8;
        if (gameObject.name == "Level9") actualLevel = 9;
        if (gameObject.name == "Level10") actualLevel = 10;

        if (gameObject.name == "Level11") actualLevel = 11;
        if (gameObject.name == "Level12") actualLevel = 12;
        if (gameObject.name == "Level13") actualLevel = 13;
        if (gameObject.name == "Level14") actualLevel = 14;
        if (gameObject.name == "Level15") actualLevel = 15;

        if (actualLevel > maxLevel)
        {
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
    }
}
