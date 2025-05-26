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
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.UseingFirstSkill && other.CompareTag("Player") && !isHit)
        {
            GameManager.Instance.PlayerHp -= 60;
            isHit = true;
            StartCoroutine(Hit());
        }
        else if (GameManager.Instance.UseingFirstSkill == true && other.CompareTag("Blocking") && !isHit)
        {
            GameManager.Instance.PlayerHp -= 30;
            isHit = true;
            StartCoroutine(Hit());
        }
    }

    IEnumerator Hit()
    {
        yield return new WaitForSeconds(2f);
        isHit = false;
    }
}
