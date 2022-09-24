using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoxinhaBehavior : Enemy
{
    public GameObject player;
    public int moveSpeed;

    public Rigidbody2D rb;
    private bool _canMove;

    void Start()
    {
        _canMove = false;
    }
    private void OnBecameVisible()
    {
        _canMove = true;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out PlayerHealth _playerHealth))
            _playerHealth.TakeDamage(enemyDamage);
    }
    
    void FixedUpdate()
    {
        if(_canMove) Move();
    }
    private void Move()
    {
        float playerPos = player.transform.position.x;
        Vector3 enemyPos = transform.position;
        Vector2 targetPos = new Vector2(playerPos, enemyPos.y);

        Vector2 position = Vector2.MoveTowards(enemyPos, targetPos, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(position);
    }
}