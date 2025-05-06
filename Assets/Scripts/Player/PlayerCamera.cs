using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] 
    private Transform target;
    [SerializeField] 
    private Vector3 offset = new Vector3(0, 3, -5);

    void Start()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        if (Player != null)
        {
            target = Player.transform;
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + target.rotation * offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 10);

            // 항상 타겟을 바라보게
            transform.LookAt(target.position + Vector3.up * 1.5f); // 머리 쪽을 바라보게 약간 위로
        }
    }
}
