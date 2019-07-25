using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class updateHp : MonoBehaviour
{
    public EnemyAI enemy;

    public Text txt;

    void Start()
    {
        // enemy = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.Health <= 0)
        {
            Destroy(txt);
        } else
        {
            txt.text = enemy.Health.ToString();
        }
    }
}
