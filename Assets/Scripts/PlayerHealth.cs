using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _playerHealth = 20;
    private int _currentHealth;
    public Canvas youDiedScreen;
    //private bool isAlive;

    void Start()
    {
        //isAlive = true;
        _currentHealth = _playerHealth;
    }

    private void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //you died screen
        //respawn
    }
}
