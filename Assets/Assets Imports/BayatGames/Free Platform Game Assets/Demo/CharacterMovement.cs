using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] public float runSpeed = 40f;

    float horizonalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizonalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }
}
