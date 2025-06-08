using UnityEngine;
using System.Collections;

public class PaladinNomalWalk : MonoBehaviour
{
    public int Speed;
    [HideInInspector]
    public Animator Ani;
    [HideInInspector]
    public Rigidbody rb;
    public Block Block;
    public bool isAttacking = false;
    private bool isMoving = false;
    private Vector3 camForward, camRight;
    public int myHp;
    public bool blocked = false;
    private bool wasBlockedNow = false;

    void Start()
    {
        Ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        myHp = GameManager.Instance.PlayerHp;
    }

    void Update()
    {
        if (GameManager.Instance.PlayerHp <= 0)
        {
            Ani.Play("PaladinDeath");
            this.gameObject.tag = "Die";
            this.gameObject.SetActive(false);
        }
        if (GameManager.Instance.PlayerHp < myHp && Block.isBlocking)
        {
            blocked = true;
        }
        myHp = GameManager.Instance.PlayerHp;
        if (GameManager.Instance.isSkillPlaying || isAttacking) return;
        if (!Block.isBlocking) gameObject.tag = "Player";
        camForward = Camera.main.transform.forward;
        camRight = Camera.main.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack());
            return;
        }

        if (Input.GetMouseButton(1))
        {
            UseBlockNow();
            return;
        }

        if (Input.GetMouseButtonUp(1))
        {
            Block.isBlocking = false;
        }
        CheckKeyboard();
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.isSkillPlaying || isAttacking) return;
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack());
            return;
        }

        if (Input.GetMouseButton(1))
        {
            UseBlockNow();
            return;
        }
        Move();
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

        if (inputDirection != Vector3.zero && !Block.isBlocking)
        {
            Vector3 camForward = Camera.main.transform.forward;
            Vector3 camRight = Camera.main.transform.right;
            camForward.y = 0; camRight.y = 0;
            camForward.Normalize(); camRight.Normalize();

            Vector3 moveDir = camForward * inputDirection.z + camRight * inputDirection.x;

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
        else if (!isMoving && !Block.isBlocking)
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

    void UseBlockNow()
    {
        if (isAttacking) return;

        bool isRightMouseDown = Input.GetMouseButton(1);

        if (isRightMouseDown && !Block.isBlocking && !GameManager.Instance.blockedNow)
        {
            Ani.Play("Block");
            Block.isBlocking = true;
            gameObject.tag = "Blocking";
        }

        if (isRightMouseDown && Block.isBlocking)
        {
            if (GameManager.Instance.blockedNow && !wasBlockedNow)
            {
                Ani.Play("Blocked");
                wasBlockedNow = true;
            }
            else if (!GameManager.Instance.blockedNow && wasBlockedNow)
            {
                Ani.Play("Block");
                wasBlockedNow = false;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            Block.isBlocking = false;
            gameObject.tag = "Player";
            wasBlockedNow = false;
        }
    }

    IEnumerator Attack()
    {
        if (Block.isBlocking) yield break;

        Ani.Play("Attack");
        isAttacking = true;
        yield return new WaitForSeconds(1.5f);
        isAttacking = false;
    }
}
