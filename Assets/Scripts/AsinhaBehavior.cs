using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsinhaBehavior : Enemy
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out PlayerHealth _playerHealth))
            _playerHealth.TakeDamage(enemyDamage);
    }
}
