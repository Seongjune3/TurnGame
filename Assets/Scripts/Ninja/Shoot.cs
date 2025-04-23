using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public NinjaWalk NinjaWalk;
    public GameObject Suriken;
    public Transform FirePos;
    private GameObject Boss;
    private GameObject Dummy;
    public bool isShooting;
    public static bool isBoss = true;
    public static bool isDummy = true;

    void Start()
    {
        Boss = GameObject.FindWithTag("Boss");
        Dummy = GameObject.FindWithTag("Dummy");
    }


    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            MakeSuriken();
            StartCoroutine(ShootingCooldown());
        }

    }

    IEnumerator ShootingCooldown()
    {
        isShooting = true;
        yield return new WaitForSeconds(1f); // 1초 대기
        isShooting = false;
    }

    void MakeSuriken()
    {
        //보스까지의 거리 계산
        Vector3 directionToBoss = (Boss.transform.position - FirePos.position).normalized;
        //더미까지의 거리 계산
        Vector3 directionToDummy = (Dummy.transform.position - FirePos.position).normalized;
        if (Boss != null && Vector3.Distance(Boss.transform.position, FirePos.transform.position) <= 15)
        {
            //보스를 바라보게 회전
            Quaternion lookRotation = Quaternion.LookRotation(directionToBoss);
            // 수리검 생성
            Instantiate(Suriken, FirePos.position, lookRotation);
            isBoss = true;
            isDummy = false;
        }
        if (Dummy != null && Vector3.Distance(Dummy.transform.position, FirePos.transform.position) <= 15)
        {
            //더미를 바라보게 회전
            Quaternion lookRotation = Quaternion.LookRotation(directionToDummy);
            // 수리검 생성
            Instantiate(Suriken, FirePos.position, lookRotation);
            isDummy = true;
            isBoss = false;
        }
    }
}