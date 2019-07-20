using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement3 : MonoBehaviour
{
    public CharacterController2D controller;
    public CharacterSwitch world;
    public Animator animator;
    [SerializeField] float runSpeed = 120f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;


    // Update is called once per frame
    void Update ()
    {
        if (world.ActivePlayer == "Player3")
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            SetAnimationByKey("z", "IsAttacking");

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                // animator.SetBool("IsJumping", true);
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

    void SetAnimationByKey(string button, string attribute)
    {
        if (Input.GetButtonDown(button))
        {
            animator.SetBool(attribute, true);
        } else if (Input.GetButtonUp("z"))
        {
            animator.SetBool(attribute, false);
        }
    }

    public void OnLanding()
    {
        // animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        if (world.ActivePlayer == "Player3")
        {
            // animator.SetBool("IsControlling", true);
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }

    }
}
