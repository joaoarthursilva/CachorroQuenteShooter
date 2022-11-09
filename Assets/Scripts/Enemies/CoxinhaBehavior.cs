using UnityEngine;

namespace Enemies
{
    public class CoxinhaBehavior : Enemy
    {
        [Header("Movement Variables")] private GameObject _player;
        // [SerializeField] private float maxMoveSpeed = 11f;

        [SerializeField] private float movementAcceleration = 55;
        public int moveSpeed;

        private Rigidbody2D _rb;
        private bool _canMove;

        [Header("Health Variables")] public int startingHealth = 10;
        private int _currentHealth;
        // public int enemyDamage = 1;
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
            var isFacingRight = playerPos <= enemyPos.x;
            if (isFacingRight)
                _rb.AddForce(new Vector2(-1, 0f) * movementAcceleration);
            else
                _rb.AddForce(new Vector2(1, 0f) * movementAcceleration);

            if (Mathf.Abs(_rb.velocity.x) > moveSpeed)
                _rb.velocity = new Vector2(Mathf.Sign(_rb.velocity.x) * moveSpeed, _rb.velocity.y);
        }
    }
}