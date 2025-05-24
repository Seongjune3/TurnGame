using UnityEngine;
using System.Collections;

public class ZeroSkill : MonoBehaviour
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
        if (GameManager.Instance.UseingZeroSkill == true && other.CompareTag("Player") && !isHit)
        {
            GameManager.Instance.PlayerHp -= 25;
            isHit = true;
            StartCoroutine(Hit());
        }
        else if (GameManager.Instance.UseingZeroSkill == true && other.CompareTag("Blocking") && !isHit)
        {
            GameManager.Instance.PlayerHp -= 15;
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
