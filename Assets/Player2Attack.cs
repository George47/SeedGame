using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Attack : MonoBehaviour
{
    private float AttackGap;
    public float StartTimeAttackGap;

    public Transform AttackPosition;
    public LayerMask IsEnemy;
    public float AttackRange;
    public int Damage;

    // Update is called once per frame
    void Update()
    {
        // if (AttackGap <= 0)
        // {
            if (Input.GetButtonDown("z"))
            {
                Debug.Log("attacked");
                Collider2D[] EnemyToDamage = Physics2D.OverlapCircleAll(AttackPosition.position, AttackRange, IsEnemy);
                for (int i = 0; i < EnemyToDamage.Length; i++)
                {
                    EnemyToDamage[i].GetComponent<EnemyAI>().TakeDamage(Damage);
                }
            }

        //     AttackGap = StartTimeAttackGap;
        // } else {
        //     AttackGap = Time.deltaTime;
        // }      
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPosition.position, AttackRange);
    }
}
