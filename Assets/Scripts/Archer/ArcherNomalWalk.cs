using UnityEngine;

public class ArcherNomalWalk : MonoBehaviour
{
    public int Speed;
    public Animator Ani;
    public Bow Bow;
    private bool isMoving = false;

    void Start()
    {
        Ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.Instance.isSkillPlaying) return;

        Move();
        CheckKeyboard();
    }

    void Move()
    {
        Vector3 inputDirection = Vector3.zero;
        bool isMovingBackward = false;
        bool isAiming = Bow.isAiming;

        if (Input.GetKey(KeyCode.W)) inputDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) { inputDirection += Vector3.back; isMovingBackward = true; }
        if (Input.GetKey(KeyCode.A)) inputDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D)) inputDirection += Vector3.right;

        inputDirection = inputDirection.normalized;

        if (inputDirection != Vector3.zero)
        {
            Vector3 camForward = Camera.main.transform.forward;
            Vector3 camRight = Camera.main.transform.right;
            camForward.y = 0; camRight.y = 0;
            camForward.Normalize(); camRight.Normalize();

            Vector3 moveDir = camForward * inputDirection.z + camRight * inputDirection.x;

            // 이동 중일 때 회전 (뒤로 이동 제외)
            if (!isMovingBackward)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 5f);
            }

            transform.Translate(moveDir.normalized * Speed * Time.deltaTime, Space.World);

            // 애니메이션
            string animPrefix = isAiming ? "Aim Walk" : "Walk";
            string animName = isMovingBackward ? animPrefix + " Back" : animPrefix + " Forward";
            Ani.Play(animName);

            isMoving = true;
        }
        else if (!isMoving && !isAiming)
        {
            Ani.Play("Idle");
        }
    }

    void CheckKeyboard()
    {
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) &&
            !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            isMoving = false;
        }
    }
}
