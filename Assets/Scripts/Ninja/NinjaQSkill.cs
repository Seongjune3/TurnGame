using UnityEngine;
using System.Collections;

public class NinjaQSkill : CoolTime
{
    [SerializeField]
    bool isUseSkill = false;  
    bool isCoolTime = false; 
    protected override void UseSkill(SkillCooldown skill)
    {
        if (skill.key == KeyCode.Q && !isCoolTime && !GameManager.Instance.isSkillPlaying)
        {
            GameManager.Instance.isSkillPlaying = true;
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
        GameManager.Instance.isSkillPlaying = false;
        isUseSkill = false;
    }
}
