using UnityEngine;
using System.Collections;

public class NinjaXSkill : CoolTime
{
    [SerializeField]
    bool isUseSkill = false;
    bool isCoolTime = false;
    protected override void UseSkill(SkillCooldown skill)
    {
        if (skill.key == KeyCode.X && !isCoolTime && !GameManager.Instance.isSkillPlaying)
        {
            GameManager.Instance.isSkillPlaying = true;
            FindAnyObjectByType<NinjaWalk>().Speed += 3;
            FindAnyObjectByType<NinjaWalk>().DiagonalSpeed += 3;
            FindAnyObjectByType<NinjaNomalWalk>().Speed += 3;
            StartCoroutine(SkillCoolDown());
            StartCoroutine(ChangeSpeed());
            ani.Play("Buff Skill");
        }
    }

    IEnumerator SkillCoolDown()
    {
        isCoolTime = true;
        yield return new WaitForSeconds(60f);
        isCoolTime = false;
    }

    IEnumerator ChangeSpeed()
    {
        isUseSkill = true;
        yield return new WaitForSeconds(1f);
        isUseSkill = false;
        GameManager.Instance.isSkillPlaying = false;
        yield return new WaitForSeconds(10f);
        FindAnyObjectByType<NinjaWalk>().Speed -= 3;
        FindAnyObjectByType<NinjaWalk>().DiagonalSpeed -= 3;
        FindAnyObjectByType<NinjaNomalWalk>().Speed -= 3;
    }
}