using UnityEngine;
using System.Collections;

public class ArcherZSkill : CoolTime
{
    bool isCoolTime = false;
    public Bow bow;
    Vector3 ArrowRotation = new Vector3(90, 0, 0);

    protected override void UseSkill(SkillCooldown skill)
    {
        if (skill.key == KeyCode.Z && !isCoolTime && !GameManager.Instance.isSkillPlaying)
        {
            if (Vector3.Distance(bow.Boss.transform.position, bow.FirePos.transform.position) > 25 && GameManager.Instance.PlayerIsComming)
            {
                return;
            }
            if (Vector3.Distance(bow.Dummy.transform.position, bow.FirePos.transform.position) > 25 && !GameManager.Instance.PlayerIsComming)
            {
                return;
            }
            GameManager.Instance.isSkillPlaying = true;
            MakeArrows();
            StartCoroutine(SkillCoolDown());
            StartCoroutine(ChangeBool());
            ani.Play("Standing Aim");
        }
    }

    IEnumerator SkillCoolDown()
    {
        isCoolTime = true;
        yield return new WaitForSeconds(15f);
        isCoolTime = false;
    }

    IEnumerator ChangeBool()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.isSkillPlaying = false;
    }

    void MakeArrows()
    {
        //보스까지의 거리 계산
        Vector3 directionToBoss = (bow.Boss.transform.position - bow.FirePos.position).normalized;
        Vector3 directionToDummy = (bow.Dummy.transform.position - bow.FirePos.position).normalized;
        if (Vector3.Distance(bow.Boss.transform.position, bow.FirePos.transform.position) <= 25)
        {
            //보스를 바라보게 회전
            Quaternion lookRotation = Quaternion.LookRotation(directionToBoss);

            //회전값 보정
            Quaternion arrowRotationOffset = Quaternion.Euler(ArrowRotation);

            //보스를 바라보게 한 회전값 * 보정한 회전값
            Quaternion finalRotation = lookRotation * arrowRotationOffset;

            //화살 생성
            Instantiate(bow.Arrows, bow.FirePos.position, finalRotation);
            Instantiate(bow.Arrows, bow.FirePos.position, finalRotation);
            Instantiate(bow.Arrows, bow.FirePos.position, finalRotation);
            Bow.isBoss = true;
            Bow.isDummy = false;
        }

        if (Vector3.Distance(bow.Dummy.transform.position, bow.FirePos.transform.position) <= 25)
        {
            //더미를 바라보게 회전
            Quaternion lookRotation = Quaternion.LookRotation(directionToDummy);

            //회전값 보정
            Quaternion arrowRotationOffset = Quaternion.Euler(ArrowRotation);

            //더미를 바라보게 한 회전값 * 보정한 회전값
            Quaternion finalRotation = lookRotation * arrowRotationOffset;

            //화살 생성
            Instantiate(bow.Arrows, bow.FirePos.position, finalRotation);
            Instantiate(bow.Arrows, bow.FirePos.position, finalRotation);
            Instantiate(bow.Arrows, bow.FirePos.position, finalRotation);
            Bow.isBoss = false;
            Bow.isDummy = true;
        }
    }
}
