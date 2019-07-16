using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class vcamChange : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;

    public CharacterSwitch world;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (world.ActivePlayer == "Player1")
        {
            vcam.m_Follow = GameObject.Find("Player").transform;
        } else if (world.ActivePlayer == "Player2")
        {
            vcam.m_Follow = GameObject.Find("Enemy2").transform;
        }
    }
}
