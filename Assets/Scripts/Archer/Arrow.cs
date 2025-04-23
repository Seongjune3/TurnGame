    using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private GameObject Boss;
    [SerializeField]
    private GameObject Dummy;
    public GameObject weponObject;
    public WeponController wepon;
    private int ArrowDmg = 25;

    void Start()
    {
        Boss = GameObject.FindWithTag("Boss");
        Dummy = GameObject.FindWithTag("Dummy");
        weponObject = GameObject.FindWithTag("NpcObject");
        wepon = weponObject.GetComponent<WeponController>();
    }


    void Update()
    {
        MoveToBoss();
    }

    void MoveToBoss()
    {
        if (Boss != null)
        {
            //화살쏘는 지점을 1올림
            Vector3 TargetPos = Boss.transform.position + new Vector3(0, 1, 0);
            Vector3 DummyTargetPos = Dummy.transform.position + new Vector3(0, 1, 0);
            //화살이 보스에게 가기까지의 거리 계산 (목표 위치 - 내 위치)
            Vector3 direction = TargetPos - transform.position;
            Vector3 Dummydirection = DummyTargetPos - transform.position;

            if (Boss != null && Bow.isBoss)
            {
                //거리만큼 이동
                transform.Translate(direction.normalized * Time.deltaTime * 15, Space.World);
            }
            if (Dummy != null && Bow.isDummy)
            {
                //거리만큼 이동
                transform.Translate(Dummydirection.normalized * Time.deltaTime * 15, Space.World);
            }
        }
    }

    //보스에게 충돌했는지 확인 및 삭제
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            Destroy(gameObject);
            Debug.Log("보스");
            GameManager.Instance.FirstBossHp -= ArrowDmg + wepon.myWepon.data.plusDmg;
        }
        if (other.CompareTag("Dummy"))
        {
            Destroy(gameObject);
            Debug.Log("더미");
        }
    }
}