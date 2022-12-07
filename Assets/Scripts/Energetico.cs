using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Energetico : MonoBehaviour
{
    [SerializeField] private int regenAmount;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        _playerHealth.RegenerateHealth(regenAmount);
        gameObject.SetActive(false);
    }
}