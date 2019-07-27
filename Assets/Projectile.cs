using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public CircleCollider2D Collider;

    public LayerMask IsEnemy;
    public int Damage;

    void Start()
    {
        Collider.offset = new Vector2(0.28f, 0f);
        Collider.radius = 0.25f;
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    private void Update()
    {
        Collider2D[] EnemyToDamage = Physics2D.OverlapCircleAll(rb.position, Collider.radius, IsEnemy);
        for (int i = 0; i < EnemyToDamage.Length; i++)
        {
            // Enemy.IsAttacked = true;
            EnemyToDamage[i].GetComponent<EnemyAI>().TakeDamage(Damage);
        }
        
        // transform.Translate(transform.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        EnemyAI enemy = hitInfo.GetComponent<EnemyAI>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damage);
        }

        Destroy(gameObject);    
    }

}
