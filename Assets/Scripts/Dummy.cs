using UnityEngine;
using System.Collections;

public class Dummy : MonoBehaviour
{
    public Animator ani;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wepon"))
        {
            ani.Play("Hurt");
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        ani.Play("Idle");
    }
}
