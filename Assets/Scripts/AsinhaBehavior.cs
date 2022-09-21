using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class AsinhaBehavior : Enemy
{
    public Transform target;

    public float speed = 300f;
    public float nextWaypointDistance = 3f;
    private Path _path;
    private int _currentWaypoint = 0;
    private bool _reachedEndOfPath = false;
    private Seeker _seeker;
    private Rigidbody2D _rb;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out PlayerHealth playerHealth))
            playerHealth.TakeDamage(enemyDamage);
    }

    private void Update()
    {
    }
}
