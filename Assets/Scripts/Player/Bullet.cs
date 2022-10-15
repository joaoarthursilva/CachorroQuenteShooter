using System.Collections.Generic;
using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class Bullet : MonoBehaviour
    {
        public int bulletDamage;
        public List<Sprite> sprites;
        private void Start()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 2)];
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.TryGetComponent(out Enemy enemy))
                enemy.TakeDamage(bulletDamage);
            if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Ignore"))
            {
                //arrumar isso
                Physics2D.IgnoreCollision(collider, gameObject.GetComponent<BoxCollider2D>());
                return;
            }
            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}