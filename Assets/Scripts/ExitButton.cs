using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
