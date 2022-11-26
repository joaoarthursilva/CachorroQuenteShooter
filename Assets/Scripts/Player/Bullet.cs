using System.Collections.Generic;
using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class Bullet : MonoBehaviour
    {
        public int bulletDamage=1;
        public List<Sprite> sprites;
        private void Start()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 2)];
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.TryGetComponent(out Enemy enemy))
                enemy.TakeDamage(bulletDamage);
          
            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}