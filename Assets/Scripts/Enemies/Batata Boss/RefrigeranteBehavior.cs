using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RefrigeranteBehavior : Enemy
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col);
        if (col.gameObject.TryGetComponent(out PlayerHealth _playerHealth))
            _playerHealth.TakeDamage(enemyDamage);
    }
}