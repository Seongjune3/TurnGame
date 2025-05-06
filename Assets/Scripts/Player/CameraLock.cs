using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public Transform target;  // 따라갈 캐릭터의 transform
    public GameObject player;
    public float distance = 5.0f;  // 캐릭터와의 거리
    public float height = 1.5f;  // 카메라 높이
    public float sensitivity = 3.0f;  // 마우스 감도


    private float currentX = 0f;  // X축 회전값
    private float currentY = 0f;  // Y축 회전값

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // 마우스 커서 숨기기
        GameObject player = GameObject.FindWithTag("Player");
        target = player.transform;
    }

    void Update()
    {
        // 마우스 입력 받아 회전값 변경
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity;
        currentY = Mathf.Clamp(currentY, -20f, 60f);  // 위아래 시점 제한

        // 캐릭터도 함께 회전
        target.rotation = Quaternion.Euler(0, currentX, 0);
    }

    void LateUpdate()
    {
        // 카메라 위치 계산
        Vector3 direction = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = target.position + rotation * direction;
        transform.LookAt(target.position + Vector3.up * height);
    }
}
