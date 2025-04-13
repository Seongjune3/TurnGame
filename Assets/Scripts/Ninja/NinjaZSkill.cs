using UnityEngine;
using System.Collections;

public class NinjaZSkill : CoolTime
{
    [SerializeField]
    bool isUseSkill = false;
    bool isCoolTime = false;
    bool isHited = false;
    protected override void UseSkill(SkillCooldown skill)
    {
        if (skill.key == KeyCode.Z && !isCoolTime)
        {
            FindAnyObjectByType<NinjaWalk>().isSkillPlaying = true;
            StartCoroutine(SkillCoolDown());
            StartCoroutine(ChangeBool());
            ani.Play("Knife Attack");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boss") && isUseSkill && !isHited)
        {
            Debug.Log("Boss");
            isHited = true;
        }
        else if (other.gameObject.CompareTag("Dummy") && isUseSkill && !isHited)
        {
            Debug.Log("Dummy");
            isHited = true;
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
        yield return new WaitForSeconds(2f);
        FindAnyObjectByType<NinjaWalk>().isSkillPlaying = false;
        isUseSkill = false;
        isHited = false;
    }
}
