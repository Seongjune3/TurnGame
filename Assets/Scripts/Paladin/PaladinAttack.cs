using System.Collections;
using UnityEngine;

public class PaladinAttack : MonoBehaviour
{
    public PaladinWalk paladin;
    public GameObject weponObject;
    public WeponController wepon;
    private int SwordDmg = 25;
    private bool hited = false;

    void Start()
    {
        weponObject = GameObject.FindWithTag("NpcObject");
        wepon = weponObject.GetComponent<WeponController>();
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (paladin.isAttacking && other.CompareTag("Boss") && !hited)
        {
            GameManager.Instance.FirstBossHp -= SwordDmg + wepon.myWepon.data.plusDmg;
            Debug.Log("보스");
            StartCoroutine(Hited());
        }
        else if (paladin.isAttacking && other.CompareTag("Dummy") && !hited)
        {
            Debug.Log("더미");
            StartCoroutine(Hited());
        }
    }

    IEnumerator Hited()
    {
        hited = true;
        yield return new WaitForSeconds(1.5f);
        hited = false;
    }
}