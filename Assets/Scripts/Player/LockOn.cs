using UnityEngine;

public class LockOn : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset = new Vector3(0, 3, -10);
    [SerializeField]
    private Transform dummyTarget;

    private bool Locking = false;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject dummy = GameObject.FindWithTag("Dummy");

        if (player != null)
        {
            target = player.transform;
        }

        if (dummy != null)
        {
            dummyTarget = dummy.transform;
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Locking = !Locking;
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            if (Locking && dummyTarget != null && !GameManager.Instance.PlayerIsComming)
            {
                Vector3 lockOnDirection = (dummyTarget.position - target.position).normalized;
                Vector3 lockOnPosition = target.position - lockOnDirection * offset.magnitude + Vector3.up * offset.y;
                transform.position = Vector3.Lerp(transform.position, lockOnPosition, Time.deltaTime * 2f);

                
                Quaternion lookRotation = Quaternion.LookRotation(dummyTarget.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);
            }
            else
            {
                transform.position = target.position + offset;
                transform.LookAt(target.position + Vector3.up * 1.5f);
            }
        }
    }
}