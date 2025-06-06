using UnityEngine;
using UnityEngine.SceneManagement;

public class ChosePlayer : MonoBehaviour
{
    public void ChoseNinja()
    {
        GameManager.Instance.PlayNinja = true;
        SceneManager.LoadScene("Game");
    }

    public void ChoseArcher()
    {
        GameManager.Instance.PlayArcher = true;
        SceneManager.LoadScene("Game");
    }

    public void ChosePaladin()
    {
        GameManager.Instance.PlayPaladin = true;
        SceneManager.LoadScene("Game");
    }
}
