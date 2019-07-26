using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private void Start()
    {
        HealthSystem healthSystem = new HealthSystem(5);

        Debug.Log("Health is " + healthSystem.GetHealth());
 
        // healthSystem.Damage(1);
        // Debug.Log("Taken damage " + healthSystem.GetHealth());
    }
    
}
