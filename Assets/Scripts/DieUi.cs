using UnityEngine;
using UnityEngine.SceneManagement;

public class DieUi : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Main");
    }
}
