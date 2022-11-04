using Player;
using UnityEngine;

namespace Enemies
{
    public class CoxinhaExplosion : MonoBehaviour
    {
        public int explosionDamage = 1;
        public float raioExplosao = 2.9f;
        public float timeToExplosion = .7f;
        private int _counter;
        public GameObject coxinha;

        private void Start()
        {
            gameObject.GetComponent<CircleCollider2D>().radius = raioExplosao;
            _counter = 0;
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            if (_counter != 0) return;
            if (timeToExplosion > 0) return;

            if (col.gameObject.TryGetComponent(out PlayerHealth playerHealth))
                playerHealth.TakeDamage(explosionDamage);
            else if (col.gameObject.TryGetComponent(out Enemy enemy))
                enemy.TakeDamage(explosionDamage);
            _counter++;
        }

        private void FixedUpdate()
        {
            if (timeToExplosion <= 0)
            {
                Destroy(coxinha, .1f);
            }

            timeToExplosion -= Time.fixedDeltaTime;
        }
    }
}