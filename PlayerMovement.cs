using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerDeath
{  
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    public bool jump = false;
    

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //Makes the character automatically jump based on the timer value that gets reset
        autoJump -= Time.deltaTime;
        if (autoJump < 0.0)
        {
            autoJump = 3.5f;
        }
        else if (autoJump < 1.0 && autoJump > 0.5)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        //Moves the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
