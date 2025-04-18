using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NinjaWalk : MonoBehaviour
{
    public int Speed;
    public int DiagonalSpeed;
    public Animator Ani;
    bool isMoving = false;
    public Shoot Shoot;
    private Dictionary<Vector3, string> animationMap = new Dictionary<Vector3, string>();
    public bool isSkillPlaying = false;

    void Start()
    {
        Ani = GetComponent<Animator>();

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
        Move();
        CheckKeyborad();;
    }

    void Move()
    {
        if (isSkillPlaying) return;

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) moveDirection += Vector3.back;
        if (Input.GetKey(KeyCode.A)) moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D)) moveDirection += Vector3.right;

        if (moveDirection != Vector3.zero)
        {
            // (? : 설명) 앞에 코드(moveDirection.x != 0 && moveDirection.z != 0) 가 참이면 ? 뒤에 변수로 지정 거짓이라면 : 변수로 지정
            float moveSpeed = (moveDirection.x != 0 && moveDirection.z != 0) ? DiagonalSpeed : Speed;
            transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);

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
        else if (!isMoving)
        {
            Ani.Play("Idle");
        }
    }
    
    void CheckKeyborad()
    {
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            isMoving = false;
        }
    }
}