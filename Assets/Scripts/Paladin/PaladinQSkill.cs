using UnityEngine;
using System.Collections;

public class PaladinQSkill : CoolTime
{
    [SerializeField]
    bool isUseSkill = false;  
    bool isCoolTime = false; 
    protected override void UseSkill(SkillCooldown skill)
    {
        if (skill.key == KeyCode.Q && !isCoolTime)
        {
            FindAnyObjectByType<PaladinWalk>().isSkillPlaying = true;
            StartCoroutine(SkillCoolDown());
            StartCoroutine(ChangeBool());
            ani.Play("Kick");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boss") && isUseSkill)
        {
            Debug.Log("Boss");
        }
        else if (other.gameObject.CompareTag("Dummy") && isUseSkill)
        {
            Debug.Log("Dummy");
        }
    }

    IEnumerator SkillCoolDown()
    {
        isCoolTime = true;
        yield return new WaitForSeconds(10f);
        isCoolTime = false;
    }

    IEnumerator ChangeBool()
    {
        isUseSkill = true;
        yield return new WaitForSeconds(1.5f);
        FindAnyObjectByType<PaladinWalk>().isSkillPlaying = false;
        isUseSkill = false;
    }
}
