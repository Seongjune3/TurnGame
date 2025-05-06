using UnityEngine;


public class NinjaNomalWalk : MonoBehaviour
{
    public int Speed;
    public Animator Ani;
    public bool isAttacking = false;
    private bool isMoving = false;

    void Start()
    {
        Ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.Instance.isSkillPlaying || isAttacking) return;
        Move();
        CheckKeyboard();
    }

    void Move()
    {
        Vector3 inputDirection = Vector3.zero;
        bool isMovingBackward = false;

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

            if (!isMovingBackward)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 5f);
            }

            transform.Translate(moveDir.normalized * Speed * Time.deltaTime, Space.World);
            Ani.Play(isMovingBackward ? "Walk Back" : "Walk Forward");

            isMoving = true;
        }
        else if (!isMoving)
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
