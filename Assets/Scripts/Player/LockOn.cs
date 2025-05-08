using UnityEngine;

public class LockOn : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private GameObject dummy;
    
    private bool isLockOn = false;


    void Start()
    {
        player = gameObject;
        boss = GameObject.FindWithTag("Boss");
        dummy = GameObject.FindWithTag("Dummy");   
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (isLockOn)
            {
                isLockOn = false;
            }

            if (Vector3.Distance(boss.transform.position , player.transform.position) <= 25)
            {
                isLockOn = true;
            }
            if (Vector3.Distance(dummy.transform.position , player.transform.position) <= 25)
            {
                isLockOn = true;
            }
        }
    }
}