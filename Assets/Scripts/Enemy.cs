using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _startingHealth = 10;
    private int _currentHealth;
    
    void Start()
    {
        _currentHealth = _startingHealth;
    }
    void Update()
    {
        if (_currentHealth==0)
            Destroy(gameObject);
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        _currentHealth = 0;
    }
}
