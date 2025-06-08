using UnityEngine;
using UnityEngine.SceneManagement;

public class DieUi : MonoBehaviour
{
    public GameObject dieUi;



    public void Restart()
    {
        GameManager.Instance.PlayerHp = 500;
        GameManager.Instance.PlayerMoney = 500;
        GameManager.Instance.FirstBossHp = 1500;
        GameManager.Instance.PlayerIsComming = false;
        dieUi.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void GoTitle()
    {
        GameManager.Instance.PlayerHp = 500;
        GameManager.Instance.PlayerMoney = 500;
        GameManager.Instance.FirstBossHp = 1500;
        GameManager.Instance.PlayArcher = false;
        GameManager.Instance.PlayNinja = false;
        GameManager.Instance.PlayPaladin = false;
        GameManager.Instance.PlayerIsComming = false;
        SceneManager.LoadScene("Main");
    }
}
