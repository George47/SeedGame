using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// namespace worldControl {
    public class CharacterSwitch : MonoBehaviour
    {
        public bool StartGame = false;

        public string ActivePlayer = "Player3";
        
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
            } else if (Input.GetButtonDown("3"))
            {
                ActivePlayer = "Player3";
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

        public void loadScene2()
        {
             SceneManager.LoadScene (sceneName:"Scene2");
            //  SceneManager.UnloadScene (sceneName:"PlatformGame");
        }

    }

// }
