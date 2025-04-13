using UnityEngine;

public class SecondSkill : MonoBehaviour
{
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.UseingSecondSkill == true && other.CompareTag("Player"))
        {
            GameManager.Instance.PlayerHp -= 50;
        }
    }
}
