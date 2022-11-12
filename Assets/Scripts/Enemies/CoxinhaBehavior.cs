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
        private GameObject explosaoCoxinha;

        [Header("Animation Variables")] [SerializeField]
        private Animator coxinhaAnimator;

        private static readonly int IsExploding = Animator.StringToHash("IsExploding");
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            _rb = gameObject.GetComponent<Rigidbody2D>();
            _currentHealth = startingHealth;
            _canMove = false;
            _exploding = false;
            explosaoCoxinha.SetActive(false);
            coxinhaAnimator.SetBool(IsRunning, true);
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

        // private void OnCollisionStay2D(Collision2D col)
        // {
        //     if (col.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        //         playerHealth.TakeDamage(enemyDamage);
        // }

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
            coxinhaAnimator.SetBool(IsRunning, false);
            coxinhaAnimator.SetBool(IsExploding, true);
            if (coxinhaAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 &&
                !coxinhaAnimator.IsInTransition(0))
            {
                explosaoCoxinha.SetActive(true);
            }

            // esperar o tempo
        }

        private void FixedUpdate()
        {
            if (_canMove && !_exploding) Move();
            var isRunning = _rb.velocity.x != 0;
            coxinhaAnimator.SetBool(IsRunning, isRunning);
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