using System;
using Player;
using UnityEngine;

namespace Enemies
{
    public class CoxinhaExplosion : MonoBehaviour
    {
        public int explosionDamage = 1;
        public float raioExplosao;

        private void Start()
        {
            gameObject.GetComponent<CircleCollider2D>().radius = raioExplosao;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out PlayerHealth playerHealth))
                playerHealth.TakeDamage(explosionDamage);
        }
    }
}