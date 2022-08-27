using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _playerHealth = 20;
    private int _currentHealth;
    private bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        _currentHealth = _playerHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    private void Die()
    {
        //you died screen
        //respawn
    }
}
