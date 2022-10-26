using Player;
using UnityEngine;

namespace Enemies
{
    public class PastelMovement : Enemy
    {
        [Header("Movement Variables")] private GameObject _player;
        public int moveSpeed;
        private Rigidbody2D _rb;
        private bool _canMove;

        public int startingHealth = 10;
        private int _currentHealth;
        public int enemyDamage = 5;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            _rb = gameObject.GetComponent<Rigidbody2D>();
            _currentHealth = startingHealth;
            _canMove = false;
        }

        private void OnBecameVisible()
        {
            _canMove = true;
        }

        public override void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            if (_currentHealth <= 0)
                Destroy(gameObject);
        }

        private void Update()
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = !(_player.transform.position.x > transform.position.x);
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
                playerHealth.TakeDamage(enemyDamage);
        }

        private void FixedUpdate()
        {
            if (_canMove) Move();
        }

        private void Move()
        {
            var playerPos = _player.transform.position.x;
            var enemyPos = transform.position;
            var targetPos = new Vector2(playerPos, enemyPos.y);

            var position = Vector2.MoveTowards(enemyPos, targetPos, moveSpeed * Time.fixedDeltaTime);
            _rb.MovePosition(position);
        }
    }
}