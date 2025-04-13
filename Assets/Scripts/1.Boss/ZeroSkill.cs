using UnityEngine;

public class ZeroSkill : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (GameManager.Instance.UseingZeroSkill == true && other.CompareTag("Player"))
        {
            GameManager.Instance.PlayerHp -= 25;
        }
    }
}