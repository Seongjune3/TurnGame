using UnityEngine;

public class Suriken : MonoBehaviour
{
    [SerializeField]
    private GameObject Boss;
    [SerializeField]
    private GameObject Dummy;
    [SerializeField]
    private GameObject Surikens;
    [SerializeField]
    private int SurikenDmg = 25;
    public GameObject weponObject;
    public WeponController wepon;


    void Start()
    {
        Boss = GameObject.FindWithTag("Boss");
        Dummy = GameObject.FindWithTag("Dummy");
        Surikens = gameObject;
        weponObject = GameObject.FindWithTag("NpcObject");
        wepon = weponObject.GetComponent<WeponController>();
    }


    void Update()
    {
        MoveToBoss();
    }

    void MoveToBoss()
    {
        //화살쏘는 지점을 1올림
        Vector3 BossTargetPos = Boss.transform.position + new Vector3(0, 1, 0);
        Vector3 DummyTargetPos = Dummy.transform.position + new Vector3(0, 1, 0);
        //화살이 보스에게 가기까지의 거리 계산 (목표 위치 - 내 위치)
        Vector3 Bossdirection = BossTargetPos - transform.position;
        Vector3 Dummydirection = DummyTargetPos - transform.position;
        if (Boss != null && Shoot.isBoss)
        {
            //거리만큼 이동
            transform.Translate(Bossdirection.normalized * Time.deltaTime * 5, Space.World);
            //계속 회전
            Surikens.transform.Rotate(0, 5000 * Time.deltaTime, 0);
        }
        if (Dummy != null && Shoot.isDummy)
        {
            //거리만큼 이동
            transform.Translate(Dummydirection.normalized * Time.deltaTime * 5, Space.World);
            //계속 회전
            Surikens.transform.Rotate(0, 5000 * Time.deltaTime, 0);
        }
    }


    //보스에게 충돌했는지 확인 및 삭제
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            Destroy(gameObject);
            Debug.Log("보스");
            GameManager.Instance.FirstBossHp -= SurikenDmg + wepon.myWepon.data.plusDmg;
        }
        if (other.CompareTag("Dummy"))
        {
            Destroy(gameObject);
            Debug.Log("더미");
        }
    }
}
