using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
       animator = GetComponent<Animator>();
    }



    void Update()
    {
        
        animator.ResetTrigger("MoveLeft");
        animator.ResetTrigger("MoveRight");
        animator.ResetTrigger("MoveUp");
        animator.ResetTrigger("MoveDown");

        bool isMoving = false;

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetTrigger("MoveLeft");
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetTrigger("MoveRight");
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            animator.SetTrigger("MoveUp");
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetTrigger("MoveDown");
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            animator.SetTrigger("Dead State");
            isMoving = true;
        }




        if (!isMoving)
        {
            animator.SetBool("IsIdle", true);
        }
        else
        {
            animator.SetBool("IsIdle", false);
        }
    }
}












