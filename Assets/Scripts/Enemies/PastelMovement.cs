using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastelMovement : Enemy
{
    private Rigidbody2D _rb;
    public int velocidade;
    private bool _canMove;
    private Vector2 _forca;

    void Start()
    {
         _forca = new Vector2(-velocidade, 0);
        _canMove = false;
        _rb = gameObject.GetComponent<Rigidbody2D>();
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
        if(_canMove) _rb.AddForce(_forca);
    }
}