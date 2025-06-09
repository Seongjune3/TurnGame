using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearUi : MonoBehaviour
{
    public GameObject clearUi;
    public GameObject player;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    void Update()
    {
        if (GameManager.Instance.FirstBossHp <= 0)
        {
            player.SetActive(false);
            clearUi.SetActive(true);
        }
    }

    public void Restart()
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