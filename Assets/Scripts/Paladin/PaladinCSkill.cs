using UnityEngine;
using System.Collections;
using UnityEngine.VFX;

public class PaladinCSkill : CoolTime
{
    [SerializeField]
    bool isUseSkill = false;
    bool isCoolTime = false;
    public VisualEffect slashVFX;
    public Transform slashPos;

    protected override void UseSkill(SkillCooldown skill)
    {
        if (skill.key == KeyCode.C && !isCoolTime && !GameManager.Instance.isSkillPlaying)
        {
            GameManager.Instance.isSkillPlaying = true;
            StartCoroutine(SkillCoolDown());
            StartCoroutine(ChangeBool());
            StartCoroutine(SlashVFXSpawn());
            ani.Play("Slash");
        }
    }

    IEnumerator SkillCoolDown()
    {
        isCoolTime = true;
        yield return new WaitForSeconds(30f);
        isCoolTime = false;
    }

    IEnumerator ChangeBool()
    {
        isUseSkill = true;
        yield return new WaitForSeconds(2.5f);
        GameManager.Instance.isSkillPlaying = false;
        isUseSkill = false;
    }

    IEnumerator SlashVFXSpawn()
    {
        yield return new WaitForSeconds(0.7f);
        Instantiate(slashVFX , slashPos.position , slashPos.rotation);
    }
}
