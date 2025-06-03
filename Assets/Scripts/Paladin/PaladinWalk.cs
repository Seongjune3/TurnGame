using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PaladinWalk : MonoBehaviour
{
    public int Speed;
    public int DiagonalSpeed;
    [HideInInspector]
    public Animator Ani;
    [HideInInspector]
    public Rigidbody rb;
    public Block Block;
    public bool isAttacking = false;
    private bool isMoving = false;

    private Dictionary<Vector3, string> animationMap = new Dictionary<Vector3, string>();
    // Dictionary<변수 , 변수> 변수 이름 
    // ex) Dictionary<string , int> Test = new Dictionary<string , int>();
    //Test["ABC"] = 25;
    //Test["abc"] = 50;
    //이제 Test가 ABC면 25 abc면 50 출력



    void Start()
    {
        Ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        // 이동 방향과 애니메이션 매핑
        animationMap[new Vector3(1, 0, 1)] = "Walk Right";  // W + D
        animationMap[new Vector3(-1, 0, 1)] = "Walk Left";   // W + A
        animationMap[new Vector3(0, 0, 1)] = "Walk Forward"; // W
        animationMap[new Vector3(1, 0, -1)] = "Walk Right";  // S + D
        animationMap[new Vector3(-1, 0, -1)] = "Walk Left";  // S + A
        animationMap[new Vector3(0, 0, -1)] = "Walk Back";   // S
        animationMap[new Vector3(-1, 0, 0)] = "Walk Left";   // A
        animationMap[new Vector3(1, 0, 0)] = "Walk Right";   // D
    }

    void Update()
    {
        if (GameManager.Instance.PlayerHp <= 0)
        {
            Ani.Play("PaladinDeath");
            this.gameObject.tag = "Die";
            this.enabled = false;
        }
        if (GameManager.Instance.isSkillPlaying) return;
        if (!Block.isBlocking) gameObject.tag = "Player";
        if (isAttacking) return;
        
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
        if (GameManager.Instance.isSkillPlaying) return;
        if (isAttacking) return;
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
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) moveDirection += Vector3.back;
        if (Input.GetKey(KeyCode.A)) moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D)) moveDirection += Vector3.right;

        if (moveDirection != Vector3.zero && !Block.isBlocking)
        {
            // (? : 설명) 앞에 코드(moveDirection.x != 0 && moveDirection.z != 0) 가 참이면 ? 뒤에 변수로 지정 거짓이라면 : 변수로 지정
            float moveSpeed = (moveDirection.x != 0 && moveDirection.z != 0) ? DiagonalSpeed : Speed;
            Vector3 localMove = transform.TransformDirection(moveDirection.normalized) * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + localMove);

            // 애니메이션 변경
            if (animationMap.ContainsKey(moveDirection))
            {
                Ani.Play(animationMap[moveDirection]);
            }
            else
            {
                Ani.Play("Idle");
            }

            isMoving = true;
        }
        else if (!isMoving && !Block.isBlocking)
        {
            Ani.Play("Idle");
        }
    }

    void CheckKeyboard()
    {
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            isMoving = false;
        }
    }

    void UseBlockNow()
    {
        if (isAttacking) return;

        if (Input.GetMouseButton(1) && !Block.isBlocking)
        {
            Ani.Play("Block");
            Block.isBlocking = true;
            gameObject.tag = "Blocking";
        }
        else if (Input.GetMouseButtonUp(1) && Block.isBlocking)
        {
            Block.isBlocking = false;
            gameObject.tag = "Player";
        }
    }

    IEnumerator Attack()
    {
        if (Block.isBlocking)
        {
            yield break;
        }
        Ani.Play("Attack");
        isAttacking = true;
        yield return new WaitForSeconds(1.5f);
        isAttacking = false;
    }
}