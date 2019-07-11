using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersArrayScript : MonoBehaviour
{
    public bool StartGame = false;
    
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("n"))
        {
            StartGame = !StartGame;
        }
    }
}
