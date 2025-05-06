using UnityEngine;

public class Test2 : MonoBehaviour
{
    public Transform target; // 따라갈 대상 (캐릭터)
    public Vector3 offset = new Vector3(0f, 5f, -6f); // 카메라 위치 오프셋
    public float followSpeed = 10f;

    void LateUpdate()
    {
        if (target == null) return;

        // 타겟의 회전을 기준으로 오프셋을 적용한 위치 계산
        Vector3 desiredPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * followSpeed);

        // 항상 타겟을 바라보게
        transform.LookAt(target.position + Vector3.up * 1.5f); // 머리 쪽을 바라보게 약간 위로
    }
}
