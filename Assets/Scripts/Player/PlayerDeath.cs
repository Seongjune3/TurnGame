using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathUi;


    void Start()
    {
        
    }


    void Update()
    {
        if (GameManager.Instance.PlayerHp <= 0)
        {
            deathUi.SetActive(true);
        }
    }
}
