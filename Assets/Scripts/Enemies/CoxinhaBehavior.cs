using System;
using Player;
using UnityEngine;

namespace Enemies
{
    public class CoxinhaBehavior : Enemy
    {
        [Header("Movement Variables")] private GameObject _player;
        public int moveSpeed;

        private Rigidbody2D _rb;
        private bool _canMove;

        [Header("Health Variables")] public int startingHealth = 10;
        private int _currentHealth;
        public int enemyDamage = 5;
        private bool _exploding;

        [Header("Attack Variables")] [SerializeField]
        private float timeToDamage;

        [SerializeField] private GameObject explosaoCoxinha;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            _rb = gameObject.GetComponent<Rigidbody2D>();
            _currentHealth = startingHealth;
            _canMove = false;
            _exploding = false;
            timeToDamage = .5f;
            explosaoCoxinha.SetActive(false);
        }

        public override void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            if (_currentHealth <= 0)
                Destroy(gameObject);
        }

        private void OnBecameVisible()
        {
            _canMove = true;
        }

        private void OnCollisionStay2D(Collision2D col)
        {
            if (timeToDamage <= 0 && col.gameObject.TryGetComponent(out PlayerHealth playerHealth))
                playerHealth.TakeDamage(enemyDamage);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                Explodir();
            }
        }

        private void Explodir()
        {
            _exploding = true;
            // começar animação aqui
            // esperar o tempo
            explosaoCoxinha.SetActive(true);
            // gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            if (_canMove && !_exploding) Move();
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