﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// namespace worldControl {
    public class CharacterSwitch : MonoBehaviour
    {
        public bool StartGame = false;

        public string ActivePlayer = "Player1";
        
        public Animator animator;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("1"))
            {
                ActivePlayer = "Player1";
            } else if (Input.GetButtonDown("2"))
            {
                ActivePlayer = "Player2";
            }
        }

        public void setPlayer1()
        {
            ActivePlayer = "Player1";
        }

        public void setPlayer2()
        {
            ActivePlayer = "Player2";
        }

    }

// }