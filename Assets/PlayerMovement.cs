using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
// using worldControl;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public CharactersArrayScript world;
    public Animator animator;
    [SerializeField] float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update ()
    {
        if (world.StartGame)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }            

            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            } else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        if (world.StartGame)
        {
            animator.SetBool("IsControlling", true);
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }

    }
}
