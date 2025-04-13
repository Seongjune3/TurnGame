using UnityEngine;
using System.Collections;
using UnityEngine.VFX;

public class NinjaCSkill : CoolTime
{
    [SerializeField]
    bool isUseSkill = false;
    bool isCoolTime = false;
    bool isHited = false;
    public GameObject player;
    public VisualEffect smokeVFX;

    protected override void UseSkill(SkillCooldown skill)
    {
        if (skill.key == KeyCode.C && !isCoolTime)
        {
            FindAnyObjectByType<NinjaWalk>().isSkillPlaying = true;
            StartCoroutine(SkillCoolDown());
            StartCoroutine(ChangeBool());
            StartCoroutine(SkillMove());
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
        yield return new WaitForSeconds(30f);
        isCoolTime = false;
    }

    IEnumerator ChangeBool()
    {
        isUseSkill = true;
        yield return new WaitForSeconds(2.5f);
        FindAnyObjectByType<NinjaWalk>().isSkillPlaying = false;
        isUseSkill = false;
        isHited = false;
    }

    IEnumerator SkillMove()
    {
        smokeVFX.Play();
        yield return new WaitForSeconds(1f);
        player.transform.position += new Vector3(0f, 0f, 5f);
        ani.Play("Knife Shot");
    }
}
