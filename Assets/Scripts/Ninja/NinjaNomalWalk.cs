using UnityEngine;


public class NinjaNomalWalk : MonoBehaviour
{
    public int Speed;
    [HideInInspector]
    public Animator Ani;
    [HideInInspector]
    public Rigidbody rb;
    public bool isAttacking = false;
    private bool isMoving = false;
    private Vector3 camForward, camRight;

    void Start()
    {
        Ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameManager.Instance.PlayerHp <= 0)
        {
            Ani.Play("NinjaDeath");
            this.gameObject.tag = "Die";
            this.gameObject.SetActive(false);
        }
        if (GameManager.Instance.isSkillPlaying || isAttacking) return;
        camForward = Camera.main.transform.forward;
        camRight = Camera.main.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();
        CheckKeyboard();
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.isSkillPlaying || isAttacking) return;
        Move();
    }

    void Move()
    {
        Vector3 moveDirection = Vector3.zero;
        bool isMovingBackward = false;

        if (Input.GetKey(KeyCode.W)) moveDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) { moveDirection += Vector3.back; isMovingBackward = true; }
        if (Input.GetKey(KeyCode.A)) moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D)) moveDirection += Vector3.right;

        moveDirection = moveDirection.normalized;

        if (moveDirection != Vector3.zero)
        {
            Vector3 moveDir = camForward * moveDirection.z + camRight * moveDirection.x;
            moveDir.Normalize();

            if (!isMovingBackward)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.fixedDeltaTime * 5f);
            }

            Vector3 localMove = moveDir * Speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + localMove);
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
