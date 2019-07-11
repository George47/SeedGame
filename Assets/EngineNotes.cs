using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineNotes : MonoBehaviour
{
    /*
    *  Some methods found in tutorials that utilizes engines 
    *
    */

    // ANSWER TO 3 COMMON PROBLEMS.
    // (I just started with unity but I think I have figured it out)
    // 1. "I CANT JUMP"
    // The Empty object that you created for "Ground Check" must be lower than the box/circle you created for the collider. If the collider touches the tiles but  the empty object/Ground Check doesn't the player doesn't responde to "Jump" because Jump occures only when ground check touches the ground.
    // 2. "I ALWAYS CROUCH"
    // There is an error in the code provided at the description. Just double click CharacterController2D and at the code line 67 change " !crouch" to "crouch".
    // 3."MY PLAYER DOESN'T COLLIDE AND KEEPS FALLING" 
    // Add to the tiles the component Tilemap Collider 2D.


    // GENIUS WORKS, LOGO APE WITH A LIGHT BULB

    // public CharacterController2D controller;
    // public float runSpeed = 40f;

    // float horizontalMove = 0f;
    // bool jump = false;
    // bool Crouch = false;

    // player movement
    // void update() {

    //     Debug.Log("reports to console");
    //     Input.GetAxisRaw("Horizontal"); // detects raw input, left => -1, right => 1

    //     horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


    //     // can create physics material 2D for a friction and bounciness
    //     if (Input.getButtonDown("Jump"))
    //     {
    //         jump = true;
    //     }

    //     if (Input.getButtonDown("Crouch"))
    //     {
    //         crouch = true;
    //     } else if (Input.getButtonUp("Jump"))
    //     {
    //         crouch = false;
    //     }

    // }

    // // Fixed update
    // void FixedUpdate()
    // {
    //     // time since last time called => character speed consistent, crouch, jump
    //     controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    // }


}
