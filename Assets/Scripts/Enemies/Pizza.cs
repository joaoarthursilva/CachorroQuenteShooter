using Player;
using UnityEngine;

namespace Enemies
{
    public class Pizza : Enemy
    {
        public GameObject bullet;

        public Transform shootPoint;
        public float fireRate;
        private float _nextFire;

        private bool _hasBeenRendered;
        private Transform _target;
        private Vector2 _shootpointPosition;
        [Header("Health Variables")] public int startingHealth = 10;
        private int _currentHealth;

        private void Start()
        {
            _shootpointPosition = shootPoint.position;
            _target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            _currentHealth = startingHealth;
            _hasBeenRendered = false;
            _nextFire = Time.time;
        }

        private void Update()
        {
            if (CanFire()) Fire();
        }

        private void OnBecameVisible()
        {
            _hasBeenRendered = true;
        }

        private bool CanFire()
        {
            return _hasBeenRendered && Time.time > _nextFire;
        }

        private void Fire()
        {
            var lookDir = (Vector2) _target.position - new Vector2(_shootpointPosition.x, _shootpointPosition.y);
            var angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            shootPoint.rotation = Quaternion.Euler(0f, 0f, angle + 90);
            Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            _nextFire = Time.time + fireRate;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                var thisCollider = gameObject.GetComponent<Collider2D>();
                var colliderAIgnorar = col.gameObject.GetComponent<Collider2D>();
                Physics2D.IgnoreCollision(thisCollider, colliderAIgnorar);
            }

            if (col.gameObject.TryGetComponent(out PlayerHealth playerHealth))
                playerHealth.TakeDamage(1);
        }

        public override void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            if (_currentHealth <= 0)
                Destroy(gameObject);
        }
    }
}