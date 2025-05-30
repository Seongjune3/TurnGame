using UnityEngine;

public class ComePlayer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.PlayerIsComming = true;
        }
    }
}
