using UnityEngine;

public class BlackNinjaHitBox : MonoBehaviour
{
    public NinjaCSkill ninjaCSkill;
    public bool hit = false;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boss") && ninjaCSkill.isUseSkill && !ninjaCSkill.isHited)
        {
            GameManager.Instance.FirstBossHp -= 50;
            ninjaCSkill.isHited = true;
        }
        else if (other.gameObject.CompareTag("Dummy") && ninjaCSkill.isUseSkill && !ninjaCSkill.isHited)
        {
            Debug.Log("Dummy");
            ninjaCSkill.isHited = true;
        }
    }
}
