using UnityEngine;
using System.Collections;

public class SecondSkill : MonoBehaviour
{
    bool isHit = false;
    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.UseingSecondSkill == true && other.CompareTag("Player") && !isHit)
        {
            GameManager.Instance.PlayerHp -= 50;
            isHit = true;
            StartCoroutine(Hit());
        }
        else if (GameManager.Instance.UseingSecondSkill == true && other.CompareTag("Blocking") && !isHit)
        {
            GameManager.Instance.PlayerHp -= 25;
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
