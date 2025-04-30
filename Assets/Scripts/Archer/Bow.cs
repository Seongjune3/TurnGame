using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.ProBuilder;


public class Bow : MonoBehaviour
{
    public GameObject Arrows;
    public GameObject FireArrows;
    public Transform FirePos;
    public GameObject Boss;
    public GameObject Dummy;
    public ArcherWalk ArcherWalk;
    public bool isAiming = false;
    public bool shoted = false;
    public static bool isBoss = true;
    public static bool isDummy = true;

    Vector3 ArrowRotation = new Vector3(90, 0, 0);

    void Start()
    {
        Boss = GameObject.FindWithTag("Boss");
        Dummy = GameObject.FindWithTag("Dummy");
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0) && !isAiming && !shoted)
        {
            if (Vector3.Distance(Boss.transform.position, FirePos.transform.position) > 25 && GameManager.Instance.PlayerIsComming)
            {
                return;
            }
            if (Vector3.Distance(Dummy.transform.position, FirePos.transform.position) > 25 && !GameManager.Instance.PlayerIsComming)
            {
                return;
            }
            ArcherWalk.Ani.Play("Aim Bow");
            isAiming = true;
        }
        else if (Input.GetMouseButtonUp(0) && isAiming && !shoted)
        {
            if (Vector3.Distance(Boss.transform.position, FirePos.transform.position) > 25 && GameManager.Instance.PlayerIsComming)
            {
                return;
            }
            if (Vector3.Distance(Dummy.transform.position, FirePos.transform.position) > 25 && !GameManager.Instance.PlayerIsComming)
            {
                return;
            }
            MakeArrow();
            ArcherWalk.Ani.Play("Shot Arrow");
            StartCoroutine(ChangeBool());
        }
    }
    
    IEnumerator ChangeBool()
    {
        yield return new WaitForSeconds(0.3f);
        isAiming = false;
    }

    void MakeArrow()
    {
        //보스까지의 거리 계산
        Vector3 directionToBoss = (Boss.transform.position - FirePos.position).normalized;
        Vector3 directionToDummy = (Dummy.transform.position - FirePos.position).normalized;
        if (!shoted && Vector3.Distance(Boss.transform.position, FirePos.transform.position) <= 25)
        {
            //보스를 바라보게 회전
            Quaternion lookRotation = Quaternion.LookRotation(directionToBoss);

            //회전값 보정
            Quaternion arrowRotationOffset = Quaternion.Euler(ArrowRotation);

            //보스를 바라보게 한 회전값 * 보정한 회전값
            Quaternion finalRotation = lookRotation * arrowRotationOffset;

            //화살 생성
            Instantiate(Arrows, FirePos.position, finalRotation);
            isBoss = true;
            isDummy = false;

            //화살 연사 못하게 0.5초 쿨타임
            StartCoroutine(WaitArrow());
        }

        if (!shoted && Vector3.Distance(Dummy.transform.position, FirePos.transform.position) <= 25)
        {
            //더미를 바라보게 회전
            Quaternion lookRotation = Quaternion.LookRotation(directionToDummy);

            //회전값 보정
            Quaternion arrowRotationOffset = Quaternion.Euler(ArrowRotation);

            //더미를 바라보게 한 회전값 * 보정한 회전값
            Quaternion finalRotation = lookRotation * arrowRotationOffset;

            //화살 생성
            Instantiate(Arrows, FirePos.position, finalRotation);
            isBoss = false;
            isDummy = true;

            //화살 연사 못하게 1초 쿨타임
            StartCoroutine(WaitArrow());
        }
    }

    IEnumerator WaitArrow()
    {
        shoted = true;
        yield return new WaitForSeconds(1f);
        shoted = false;
    }
}