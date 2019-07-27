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

    public GameObject projectile;
    public Transform shotPoint;
    public float offset;

    private float timeBtwShots;
    public float startTimeBtwShots;

    // Update is called once per frame
    void Update ()
    {
        if (world.ActivePlayer == "Player3")
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            
            SetAnimationByKey("z", "IsAttacking");
            // SetAnimationByKey("x", "IsRange");

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


            // firing ranged attackeed
            if (timeBtwShots <= 0)
            {
                if (Input.GetButtonDown("x"))
                {
                    animator.SetBool("IsRange", true);
                    Instantiate(projectile, shotPoint.position, transform.rotation);

                } else if (Input.GetButtonUp("x"))
                {
                    animator.SetBool("IsRange", false);
                }
            } else 
            {
                timeBtwShots -= Time.deltaTime;
            }

        }


    }

    void SetAnimationByKey(string button, string attribute)
    {
        var animation = animator.GetBool(attribute);

        if (Input.GetButtonDown(button))
        {
            if (!animation){
                animator.SetBool(attribute, true);
            }

        } else if (Input.GetButtonUp(button))
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
