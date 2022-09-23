using System;
using Pathfinding;
using UnityEngine;

public class AsinhaBehavior : Enemy
{
    private Transform target;
    public float speed = 300f;
    public float nextWaypointDistance = 3f;
    private Path _path;
    private int _currentWaypoint;
    private Seeker _seeker;
    private Rigidbody2D _rb;
    public float repeatRate=.5f;
    private Transform _transform;
    private bool _canMove;
    
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        _canMove = false;
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;

        InvokeRepeating(nameof(UpdatePath), 0f, repeatRate);
    }

    private void UpdatePath()
    {
        if(_seeker.IsDone())
            _seeker.StartPath(_rb.position, target.position, OnPathComplete);
    }
    private void OnPathComplete(Path p)
    {
        if (p.error) return;
        
        _path = p;
        _currentWaypoint = 0;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out PlayerHealth playerHealth))
            playerHealth.TakeDamage(enemyDamage);
    }

    private void OnBecameVisible()
    {
        _canMove = true;
    }

    private void Update()
    {
        transform.localScale = target.position.x > _transform.position.x
            ? new Vector3(-1f, .6f, 1f)
            : new Vector3(1f, .6f, 1f);
    }

    private void FixedUpdate()
    {
        if(_canMove) Movement();
    }

    private void Movement()
    {
        if (_path == null) return;
        if (_currentWaypoint >= _path.vectorPath.Count)
        {
            return;
        }


        Vector2 direction = ((Vector2) _path.vectorPath[_currentWaypoint] - _rb.position).normalized;
        Vector2 force = direction * (speed * Time.deltaTime);

        _rb.AddForce(force);
        
        float distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWaypoint]);
        
        if (distance < nextWaypointDistance)
        {
            _currentWaypoint++;
        }
    }
}