using UnityEngine;

public class ThirdSkill : MonoBehaviour
{
    [SerializeField]
    private Transform BossTransform;

    int MoveSpeed = 1;
    bool NowRun = false;


    void Start()
    {
        BossTransform = GameObject.FindWithTag("Boss").transform;
    }

    
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (GameManager.Instance.UseingThirdSkill && !NowRun)
        {
            Invoke("ChangeSpeed" , 2f);
            
        }
        else if (GameManager.Instance.UseingThirdSkill && NowRun)
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime, Space.Self);
            MoveSpeed = 1;
        }
        else if (!GameManager.Instance.UseingThirdSkill && NowRun)
        {
            NowRun = false;
        }
    }

    void ChangeSpeed()
    {
        MoveSpeed = 10;
        NowRun = true;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (GameManager.Instance.UseingThirdSkill && other.CompareTag("Player"))
        {
            GameManager.Instance.PlayerHp -= 50;
        }
    }
}
