using System;
using Player;
using UnityEngine;

namespace Environment
{
    public class Spawnpoint : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;

        private void Awake()
        {
            sprite.color = Color.gray;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            sprite.color = Color.white;
            if (!col.gameObject.TryGetComponent(out PlayerHealth playerHealth))
                return;
            playerHealth.SetSpawnPoint(gameObject.transform);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}