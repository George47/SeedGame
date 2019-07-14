using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// namespace worldControl {
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

        public void setPlayer1()
        {
            StartGame = true;
        }

        public void setPlayer2()
        {
            StartGame = false;
        }

    }

// }
