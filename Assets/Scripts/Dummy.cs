using UnityEngine;

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
        if (!other.CompareTag("Player") && other.CompareTag("Wepon"))
        {
            ani.Play("Hurt");
            Invoke("Wait" , 1f);
        }
    }

    void Wait()
    {
        ani.Play("Idle");
    }
}
