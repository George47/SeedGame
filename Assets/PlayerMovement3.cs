using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement3 : MonoBehaviour
{
    public CharacterController controller;
    public CharacterSwitch world;

    public Animator animator;

    // public Animator animator;
    [SerializeField] float runSpeed = 80f;

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

    public void OnLanding()
    {
        // animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        if (world.ActivePlayer == "Player3")
        {   
            Debug.Log(horizontalMove * Time.fixedDeltaTime);
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }

    }
}
