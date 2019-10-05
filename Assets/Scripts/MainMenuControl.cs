using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuControl : MonoBehaviour {

    public int maxLevel;

    GameObject levels;
    GameObject mainButtons;
    GameObject help;
	
	void Start () {
        maxLevel = PlayerPrefs.GetInt("Level", 1);
        PlayerPrefs.SetInt("Level", 15);

        if (maxLevel == 1)
        {
            GameObject.Find("Continue").GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            GameObject.Find("Continue").GetComponent<Button>().enabled = false;
        }

        mainButtons = GameObject.Find("MainButtons");
        help = GameObject.Find("Help");
        help.SetActive(false);
        levels = GameObject.Find("Levels");
        levels.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        SceneManager.LoadScene(maxLevel);
    }

    public void Level(int level)
    {
        if(level <= maxLevel) SceneManager.LoadScene(level);
    }

    public void SelectLevels(bool active)
    {
        levels.SetActive(active);
        mainButtons.SetActive(!active);
    }

    public void Help(bool active)
    {
        help.SetActive(active);
        mainButtons.SetActive(!active);
    }
}
