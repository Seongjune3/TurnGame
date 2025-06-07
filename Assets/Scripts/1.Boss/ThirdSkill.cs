using UnityEngine;
using System.Collections;

public class ThirdSkill : MonoBehaviour
{
    [SerializeField]
    private Transform BossTransform;
    [HideInInspector]
    public Rigidbody rb;

    int MoveSpeed = 1;
    bool NowRun = false;
    bool isHit = false;


    void Start()
    {
        BossTransform = GameObject.FindWithTag("Boss").transform;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (GameManager.Instance.UseingThirdSkill && !NowRun)
        {
            StartCoroutine(ChangeSpeed());
        }
        else if (!GameManager.Instance.UseingThirdSkill && NowRun)
        {
            NowRun = false;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (GameManager.Instance.UseingThirdSkill && NowRun)
        {
            Vector3 localMove = transform.forward * MoveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + localMove);
            MoveSpeed = 1;
        }
    }

    IEnumerator ChangeSpeed()
    {
        yield return new WaitForSeconds(2f);
        MoveSpeed = 5;
        NowRun = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.UseingThirdSkill && other.CompareTag("Player") && !isHit)
        {
            GameManager.Instance.PlayerHp -= 50;
            isHit = true;
            StartCoroutine(Hit());
        }
        else if (GameManager.Instance.UseingThirdSkill == true && other.CompareTag("Blocking") && !isHit)
        {
            GameManager.Instance.blockedNow = true;
            GameManager.Instance.PlayerHp -= 25;
            isHit = true;
            StartCoroutine(Hit());
            StartCoroutine(UsedBlock());
        }
    }

    IEnumerator UsedBlock()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.blockedNow = false;
    }

    IEnumerator Hit()
    {
        yield return new WaitForSeconds(2f);
        isHit = false;
    }
}
