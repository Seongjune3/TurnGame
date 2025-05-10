using UnityEngine;

public class LockOn : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public GameObject dummy;
    [SerializeField]
    private Vector3 offset = new Vector3(0, 3, -5);


    public CameraSwitch cameraSwitch;


    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        boss = GameObject.FindWithTag("Boss");
        dummy = GameObject.FindWithTag("Dummy");
    }

    void LateUpdate()
    {
        CameaLockOn();
    }

    void CameaLockOn()
    {
        if (cameraSwitch.isLockOnMode)
        {
            if (Vector3.Distance(boss.transform.position, player.transform.position) <= 25)
            {
                Vector3 desiredPosition = player.transform.position + player.transform.rotation * offset;
                transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 10);
                transform.LookAt(boss.transform.position + Vector3.up * 1.5f);

                Vector3 directionToTarget = (boss.transform.position - player.transform.position).normalized;
                directionToTarget.y = 0; // 수평 회전만 하도록 y 제거

            
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, Time.deltaTime * 100);
            }
            if (Vector3.Distance(dummy.transform.position, player.transform.position) <= 25)
            {
                Vector3 desiredPosition = player.transform.position + player.transform.rotation * offset;
                transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 10);
                transform.LookAt(dummy.transform.position + Vector3.up * 1.5f);

                Vector3 directionToTarget = (dummy.transform.position - player.transform.position).normalized;
                directionToTarget.y = 0; // 수평 회전만 하도록 y 제거


                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, Time.deltaTime * 100);
            }
        }
    }
}