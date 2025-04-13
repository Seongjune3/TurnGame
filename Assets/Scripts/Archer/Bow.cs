using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Bow : MonoBehaviour
{
    public GameObject Arrows;
    public Transform FirePos;
    private GameObject Boss;
    public ArcherWalk ArcherWalk;
    public bool isAiming = false;

    Vector3 ArrowRotation = new Vector3(90, 0, 0);

    void Start()
    {
        Boss = GameObject.FindWithTag("Boss");
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0) && !isAiming)
        {
            ArcherWalk.Ani.Play("Aim Bow");
            isAiming = true;
        }
        else if (Input.GetMouseButtonUp(0) && isAiming)
        {
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
        if (Boss != null)
        {
            //보스까지의 거리 계산
            Vector3 directionToBoss = (Boss.transform.position - FirePos.position).normalized;
            //보스를 바라보게 회전
            Quaternion lookRotation = Quaternion.LookRotation(directionToBoss);

            //회전값 보정
            Quaternion arrowRotationOffset = Quaternion.Euler(ArrowRotation);
            //보스를 바라보게 한 회전값 * 보정한 회전값
            Quaternion finalRotation = lookRotation * arrowRotationOffset;

            // 화살 생성
            Instantiate(Arrows, FirePos.position, finalRotation);
        }
    }
}