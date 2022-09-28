using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 6;
    private int _currentHealth;
    public Transform startingSpawnPoint;
    private Vector3 _currentSpawnPoint;
    public Canvas youDiedScreen;

    private bool _isDead;

    public void SetSpawnPoint(Transform spawnpoint)
    {
        _currentSpawnPoint = spawnpoint.position;
    }
    private void Start()
    {
        _currentSpawnPoint = startingSpawnPoint.position;
        Spawn();
    }

    

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }
    public void RegenerateHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Math.Min(_currentHealth, startingHealth);
    }
    
    private void Die()
    {
        Time.timeScale = 0;
        youDiedScreen.gameObject.SetActive(true);
        _isDead = true;
    }

    public bool IsDead()
    {
        return _isDead;
    }

    public void Spawn()
    {
        Time.timeScale = 1;
        gameObject.transform.position = _currentSpawnPoint;
        _isDead = false;
        youDiedScreen.gameObject.SetActive(false);
        _currentHealth = startingHealth;
    }
}