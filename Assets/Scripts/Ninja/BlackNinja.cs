using UnityEngine;

public class BlackNinja : MonoBehaviour
{
    public Animator ani;


    void Awake()
    {
        ani = GetComponent<Animator>();
    }


    void Start()
    {
        ani.Play("Knife Shot");
        Destroy(gameObject , 2f);   
    }

    
    void Update()
    {
        
    }
}
