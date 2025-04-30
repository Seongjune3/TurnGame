using UnityEngine;
using System.Collections;

public class ArcherCSkill : CoolTime
{
    bool isCoolTime = false;
    public Bow bow;
    Vector3 ArrowRotation = new Vector3(90, 0, 0);

    protected override void UseSkill(SkillCooldown skill)
    {
        if (skill.key == KeyCode.C && !isCoolTime)
        {
            if (Vector3.Distance(bow.Boss.transform.position, bow.FirePos.transform.position) > 25 && GameManager.Instance.PlayerIsComming)
            {
                return;
            }
            if (Vector3.Distance(bow.Dummy.transform.position, bow.FirePos.transform.position) > 25 && !GameManager.Instance.PlayerIsComming)
            {
                return;
            }
            FindAnyObjectByType<ArcherWalk>().isSkillPlaying = true;
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
        yield return new WaitForSeconds(0.7f);
        FindAnyObjectByType<ArcherWalk>().isSkillPlaying = false;
    }

    void MakeArrows()
    {
        //보스까지의 거리 계산
        Vector3 directionToBoss = (bow.Boss.transform.position - bow.FirePos.position).normalized;
        Vector3 directionToDummy = (bow.Dummy.transform.position - bow.FirePos.position).normalized;
        if (!bow.shoted && Vector3.Distance(bow.Boss.transform.position, bow.FirePos.transform.position) <= 25)
        {
            //보스를 바라보게 회전
            Quaternion lookRotation = Quaternion.LookRotation(directionToBoss);

            //회전값 보정
            Quaternion arrowRotationOffset = Quaternion.Euler(ArrowRotation);

            //보스를 바라보게 한 회전값 * 보정한 회전값
            Quaternion finalRotation = lookRotation * arrowRotationOffset;

            //화살 생성
            Instantiate(bow.FireArrows, bow.FirePos.position, finalRotation);
            Bow.isBoss = true;
            Bow.isDummy = false;
        }

        if (!bow.shoted && Vector3.Distance(bow.Dummy.transform.position, bow.FirePos.transform.position) <= 25)
        {
            //더미를 바라보게 회전
            Quaternion lookRotation = Quaternion.LookRotation(directionToDummy);

            //회전값 보정
            Quaternion arrowRotationOffset = Quaternion.Euler(ArrowRotation);

            //더미를 바라보게 한 회전값 * 보정한 회전값
            Quaternion finalRotation = lookRotation * arrowRotationOffset;

            //화살 생성
            Instantiate(bow.FireArrows, bow.FirePos.position, finalRotation);
            Bow.isBoss = false;
            Bow.isDummy = true;
        }
    }
}