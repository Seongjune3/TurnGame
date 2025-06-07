using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArcherWalk : MonoBehaviour
{
    public int Speed;
    public int DiagonalSpeed;
    [HideInInspector]
    public Animator Ani;
    [HideInInspector]
    public Rigidbody rb;
    private bool isMoving = false;
    public Bow Bow;

    void Start()
    {
        Ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameManager.Instance.PlayerHp <= 0)
        {
            Ani.Play("ArcherDeath");
            this.gameObject.tag = "Die";
            this.enabled = false;
        }
        CheckKeyboard();
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.isSkillPlaying) return;
        Move();
    }

    void Move()
    {   
        Vector3 moveDirection = Vector3.zero;
        
        bool isAiming = Bow.isAiming;

        if (Input.GetKey(KeyCode.W)) moveDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) moveDirection += Vector3.back;
        if (Input.GetKey(KeyCode.A)) moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D)) moveDirection += Vector3.right;

        if (moveDirection != Vector3.zero)
        {
            float moveSpeed = (moveDirection.x != 0 && moveDirection.z != 0) ? DiagonalSpeed : Speed;
            Vector3 localMove = transform.TransformDirection(moveDirection.normalized) * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + localMove);

            string animCheck = isAiming ? "Aim Walk" : "Walk";
            string animDirection = "Forward";
            if (moveDirection == (Vector3.forward + Vector3.right).normalized) animDirection = "Right";
            else if (moveDirection == (Vector3.forward + Vector3.left).normalized) animDirection = "Left";
            else if (moveDirection == (Vector3.back + Vector3.right).normalized) animDirection = "Right";
            else if (moveDirection == (Vector3.back + Vector3.left).normalized) animDirection = "Left";
            else if (moveDirection == Vector3.back) animDirection = "Back";
            else if (moveDirection == Vector3.left) animDirection = "Left";
            else if (moveDirection == Vector3.right) animDirection = "Right";

            Ani.Play(animCheck + " " + animDirection);
            isMoving = true;
        }
        else if (!isMoving && !isAiming)
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
}
