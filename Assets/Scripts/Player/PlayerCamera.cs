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
            transform.position = target.position + offset; // 캐릭터의 위치 + 오프셋
        }
    }
}
