using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider collider)
    {
        collider.GetComponent<PlayerHealth>().SetSpawnPoint(gameObject.transform);
    }
}
