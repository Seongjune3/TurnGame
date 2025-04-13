using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossMove : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private Transform Target;
    [SerializeField]
    private float MoveSpeed = 3f;
    [SerializeField]
    private float StopPoint = 1f;
    Animator Ani;
    bool PlayingAni = true;
    bool Roared = false;
    bool Cooltime = false;
    int LastUsedPattern = -1;


    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Target = GameObject.FindWithTag("Player").transform;
        Ani = GetComponent<Animator>();
    }


    void Update()
    {
        Roar();
        Move();
    }

    void Move()
    {
        if (Player != null && GameManager.Instance.PlayerIsComming && !PlayingAni)
        {
            Ani.Play("Run");
            // 거리 계산
            float distance = Vector3.Distance(transform.position, Player.transform.position);

            if (distance > StopPoint)
            {
                // 이동 방향 계산
                Vector3 direction = (Player.transform.position - transform.position).normalized;

                // 플레이어 바라보기
                transform.LookAt(Target);

                // 이동
                transform.Translate(direction * MoveSpeed * Time.deltaTime, Space.World);
            }
            else if (distance < StopPoint)
            {
                BossSkill();
            }
        }
    }

    void PlayAni()
    {
        Ani.Play("Roaring");
        PlayingAni = true;
        Invoke("EndRoaring", 4.5f);
    }

    void Roar()
    {
        if (Player != null && GameManager.Instance.PlayerIsComming && !Roared)
        {
            PlayAni();
            Roared = true;
        }
    }

    void EndRoaring()
    {
        PlayingAni = false;
    }

    void BossSkill()
    {
        if (Cooltime || PlayingAni)
        {
            return;
        }
        
        List<int> BossPatterns = new List<int> { 0, 1, 2, 3 };

        BossPatterns.Remove(LastUsedPattern);

        if (BossPatterns.Count > 0)
        {
            int RandomIndex = Random.Range(0, BossPatterns.Count);
            int SelectedPattern = BossPatterns[RandomIndex];

            switch (SelectedPattern)
            {
                case 0:
                    Ani.Play("0_Punch");
                    GameManager.Instance.UseingZeroSkill = true;
                    break;
                case 1:
                    Ani.Play("1_JumpingSkill");
                    GameManager.Instance.UseingFirstSkill = true;
                    break;
                case 2:
                    Ani.Play("2_Heavy Punch");
                    GameManager.Instance.UseingSecondSkill = true;
                    break;
                case 3:
                    Ani.Play("3_Run Attack");
                    GameManager.Instance.UseingThirdSkill = true;
                    break;
            }
            LastUsedPattern = SelectedPattern;

            StartCoroutine(SkillCooltime());
            PlayingAni = true;
        }
        
    }

    IEnumerator SkillCooltime()
    {
        Cooltime = true;
        yield return new WaitForSeconds(4f);
        Cooltime = false;
        PlayingAni = false;
        GameManager.Instance.UseingZeroSkill = false;
        GameManager.Instance.UseingFirstSkill = false;
        GameManager.Instance.UseingSecondSkill = false;
        GameManager.Instance.UseingThirdSkill = false;
    }
    
}