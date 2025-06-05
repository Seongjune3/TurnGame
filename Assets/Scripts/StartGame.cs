using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject startPanel;



    public void Setting()
    {
        settingPanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void OutSetting()
    {
        settingPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("asjaks");
    }
}