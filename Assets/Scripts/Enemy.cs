using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _startingHealth = 10;
    private int _currentHealth;
    public int enemyDamage = 5;

    void Start()
    {
        _currentHealth = _startingHealth;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("AA");
        if(col.gameObject.TryGetComponent(out PlayerHealth _playerHealth))
            _playerHealth.TakeDamage(enemyDamage);
    }
    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth<=0)
            Destroy(gameObject);
    }
}
