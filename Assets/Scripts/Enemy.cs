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
    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.GetComponent<Enemy>().TakeDamage(enemyDamage);
    }
    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth<=0)
            Destroy(gameObject);
    }
}
