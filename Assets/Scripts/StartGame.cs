using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject startPanel;
    public GameObject mainPanel;
    public GameObject chosePlayerPanel;



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
        mainPanel.SetActive(false);
        chosePlayerPanel.SetActive(true);
    }
}