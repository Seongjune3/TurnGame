using UnityEngine;
using System.Collections;

public class ArcherXSkill : CoolTime
{
    [SerializeField]
    bool isUseSkill = false;
    bool isCoolTime = false;
    protected override void UseSkill(SkillCooldown skill)
    {
        if (skill.key == KeyCode.X && !isCoolTime && !GameManager.Instance.isSkillPlaying)
        {
            GameManager.Instance.isSkillPlaying = true;
            FindAnyObjectByType<ArcherWalk>().Speed += 3;
            FindAnyObjectByType<ArcherWalk>().DiagonalSpeed += 3;
            StartCoroutine(SkillCoolDown());
            StartCoroutine(ChangeSpeed());
            ani.Play("Archer Buff");
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
        FindAnyObjectByType<ArcherWalk>().Speed -= 3;
        FindAnyObjectByType<ArcherWalk>().DiagonalSpeed -= 3;
    }
}