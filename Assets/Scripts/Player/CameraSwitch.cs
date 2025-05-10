using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public PlayerCamera playerCamera;  // 평소 카메라
    public CameraLock actionCamera;  // 액션 모드 카메라
    public LockOn lockOn;
    private Quaternion cameraRotation;

    private bool isActionMode = false;
    public bool isLockOnMode = false;

    void Start()
    {
        cameraRotation = transform.rotation;
    }

    void Update()
    {




        if (Input.GetKeyDown(KeyCode.H) && !isLockOnMode) // H 키를 누르면 전환
        {
            isActionMode = !isActionMode; // isActionMode의 값을 반대로 바꾸는 것 true -> false , false -> true

            if (isActionMode)
            {
                playerCamera.enabled = false;  // 평소 카메라 끄기
                actionCamera.enabled = true;   // 액션 모드 켜기
                Cursor.lockState = CursorLockMode.Locked;  // 마우스 커서 숨김
            }
            else
            {
                playerCamera.enabled = true;   // 평소 카메라 켜기
                actionCamera.enabled = false;  // 액션 모드 끄기
                Cursor.lockState = CursorLockMode.None;  // 마우스 커서 다시 보이게
                transform.rotation = cameraRotation;
            }
        }

        if (Input.GetKeyDown(KeyCode.G) && !isActionMode)
        {
            if (Vector3.Distance(lockOn.boss.transform.position, lockOn.player.transform.position) <= 25 ||
                Vector3.Distance(lockOn.dummy.transform.position, lockOn.player.transform.position) <= 25)
            {
                isLockOnMode = !isLockOnMode;

                if (isLockOnMode)
                {
                    playerCamera.enabled = false;
                    lockOn.enabled = true;
                }
                else
                {
                    playerCamera.enabled = true;
                    lockOn.enabled = false;
                }
            }
            else 
            {
                return;
            }
            
        }
    }
}
