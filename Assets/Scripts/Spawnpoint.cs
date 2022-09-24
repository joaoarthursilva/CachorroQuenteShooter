using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().SetSpawnPoint(gameObject.transform);
    }
}
