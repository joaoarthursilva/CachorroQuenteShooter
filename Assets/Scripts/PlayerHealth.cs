using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth = 20;
    private int _currentHealth;
    public Transform startingSpawnPoint;
    private Vector3 _currentSpawnPointPosition;
    public Canvas youDiedScreen;

    private bool _isDead;

    void Start()
    {
        _currentSpawnPointPosition = startingSpawnPoint.position;
        Spawn();
    }

    private void Update()
    {
        if (_isDead && Input.GetMouseButton(0))
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

    private void Die()
    {
        Time.timeScale = 0;
        youDiedScreen.gameObject.SetActive(true);
        _isDead = true;
    }

    private void Spawn()
    {
        Time.timeScale = 1;
        gameObject.transform.position = _currentSpawnPointPosition;
        _isDead = false;
        youDiedScreen.gameObject.SetActive(false);
        _currentHealth = playerHealth;
    }
}