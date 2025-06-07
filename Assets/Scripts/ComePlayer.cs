using UnityEngine;

public class ComePlayer : MonoBehaviour
{
    public GameObject bossHp;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.PlayerIsComming = true;
            bossHp.SetActive(true);
        }
    }
}
