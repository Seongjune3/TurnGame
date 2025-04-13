using UnityEngine;

public class FIrstSkill : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        JumpingSkill();
    }

    void JumpingSkill()
    {
        if (GameManager.Instance.UseingFirstSkill && !GameManager.Instance.PlayerIsJumping)
        {
            GameManager.Instance.PlayerHp -= 75;
        }
    }
}
