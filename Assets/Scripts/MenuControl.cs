using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

    public GameObject menu;

    void Update () {
        if (menu == null)
        {
            Debug.LogError("Menu Reference is broken");
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeSelf);
        }
        
        if(menu.activeSelf) Time.timeScale = 0;
        else Time.timeScale = 1;
	}

    public void OpenMenu(bool open)
    {
        menu.SetActive(open);
    }

    public void ChangeMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        menu.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
