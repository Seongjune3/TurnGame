using UnityEngine;
using System.Collections;

public class FIrstSkill : MonoBehaviour
{
    bool isHit = false;
    void Start()
    {

    }


    void Update()
    {
        JumpingSkill();
    }

    void JumpingSkill()
    {
        if (GameManager.Instance.UseingFirstSkill && !GameManager.Instance.PlayerIsJumping && !isHit)
        {
            GameManager.Instance.PlayerHp -= 75;
            isHit = true;
            StartCoroutine(Hit());
        }
        //else if (GameManager.Instance.UseingFirstSkill == true && other.CompareTag("Blocking") && !isHit)
        //{
        //    GameManager.Instance.PlayerHp -= 15;
        //    isHit = true;
        //    StartCoroutine(Hit());
        //}
    }

    IEnumerator Hit()
    {
        yield return new WaitForSeconds(2f);
        isHit = false;
    }
}
