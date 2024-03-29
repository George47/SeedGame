﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public CharacterSwitch world;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    // public int Health = 3;
    public bool IsAttacked = false;

    Seeker seeker;
    Rigidbody2D rb;

    HealthSystem healthSystem = new HealthSystem(3);
    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        
        Health = healthSystem.GetHealth();

        InvokeRepeating("UpdatePath", 0f, 0.5f);

        // GameObject.Find("EnemyHP").SetActive(false);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);    
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Update()
    {
        Debug.Log(IsAttacked);

        if (Health <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("EnemyHP").SetActive(false);
        }

        if (world.ActivePlayer == "Player1")
        {
            target = GameObject.Find("Player").transform;
        } else if (world.ActivePlayer == "Player2")
        {
            target = GameObject.Find("Enemy2").transform;
        } else if (world.ActivePlayer == "Player3")
        {
            target = GameObject.Find("Player2").transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {   

        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } else 
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        // normalizing makes sure length of vector is 1
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        // if (rb.velocity.x >= 0.01f)
        if (rb.velocity.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-10f, 10f, 10f);
        } else if (rb.velocity.x <= 0.01f)
        {
            enemyGFX.localScale = new Vector3(10f, 10f, 10f);
        }

    }

    public void TakeDamage(int Damage)
    {
        // GameObject.Find("EnemyHP").SetActive(true);
        Health -= Damage;
        Debug.Log("Damage Taken");
    }
}
