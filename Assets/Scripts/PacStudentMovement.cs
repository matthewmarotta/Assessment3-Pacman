using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    private Animator animator;
    private Transform spriteTransform;
    private AudioSource pacstudentMovementSound;


    private Vector3 StartPos, TopLeftPos, TopRightPos, BottomRightPos;


    [SerializeField] private float speed = 2.0f;


    private Vector3[] positions;
    private int currentTargetIndex = 0;


    private float travelTime;
    private float journeyStartTime;
    private Vector3 originalPos;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteTransform = GetComponent<Transform>();

        GameObject soundObject = GameObject.Find("pacstudentMovementSound");
        pacstudentMovementSound = soundObject.GetComponent<AudioSource>();




        StartPos = new Vector3(-5.485f, 2.501f, 0f);
        TopLeftPos = new Vector3(-5.485f, 6.546f, 0f);
        TopRightPos = new Vector3(-0.484f, 6.546f, 0f);
        BottomRightPos = new Vector3(-0.484f, 2.501f, 0f);

        positions = new Vector3[] { StartPos, TopLeftPos, TopRightPos, BottomRightPos };

        spriteTransform.position = StartPos;
        NextMovement();

    }

    void Update()
    {
        float t = (Time.time - journeyStartTime) / travelTime;
        t = Mathf.Clamp01(t);
        spriteTransform.position = Vector3.Lerp(originalPos, positions[currentTargetIndex], t);
        //for every 0.5 seconds play sound




        if (t >= 1.0f)
        {
            NextMovement();
            AnimateMovement();
            PlaySound();
        }


    }

    private void NextMovement()
    {
        originalPos = spriteTransform.position;

        currentTargetIndex = (currentTargetIndex + 1) % positions.Length;

        float distance = Vector3.Distance(originalPos, positions[currentTargetIndex]);
        travelTime = distance / speed;

        journeyStartTime = Time.time;

    }

    private IEnumerator PlaySound()
    {
        float t = (Time.time - journeyStartTime) / travelTime;
        t = Mathf.Clamp01(t);
        spriteTransform.position = Vector3.Lerp(originalPos, positions[currentTargetIndex], t);

        while (true)
        {
            if (t > 0 || t < 1)
            {
                pacstudentMovementSound.Play();
            }
            yield return new WaitForSeconds(10.0f);
        }
    }

    private void AnimateMovement()
    {
        Debug.Log("Animate Movement Called");
        if (currentTargetIndex == 1)
        {
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("isMovingRight", false);
            animator.SetBool("isMovingDown", false);
            animator.SetBool("isMovingUp", true);
            Debug.Log("Moving up");
        }
        else if (currentTargetIndex == 2)
        {
            animator.SetBool("isMovingUp", false);
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("isMovingDown", false);
            animator.SetBool("isMovingRight", true);
            Debug.Log("Moving right");
        }
        else if (currentTargetIndex == 3)
        {
            animator.SetBool("isMovingUp", false);
            animator.SetBool("isMovingRight", false);
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("isMovingDown", true);
            Debug.Log("Moving down");
        }
        else if (currentTargetIndex == 0)
        {
            animator.SetBool("isMovingUp", false);
            animator.SetBool("isMovingRight", false);
            animator.SetBool("isMovingDown", false);
            animator.SetBool("isMovingLeft", true);
            Debug.Log("Moving left");
        }
    }
}




/* MOVEMENT WITH INPUT: 
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
        }*/










