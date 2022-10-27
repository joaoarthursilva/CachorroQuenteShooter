using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class PizzaBullet : MonoBehaviour
{
    public float moveSpeed = 17f;
    private Rigidbody2D _rb;

    private Transform _target;
    private Vector2 _moveDirection;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _moveDirection = (_target.transform.position - transform.position).normalized * moveSpeed;
        _rb.velocity = new Vector2(_moveDirection.x, _moveDirection.y);
        // Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        col.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}