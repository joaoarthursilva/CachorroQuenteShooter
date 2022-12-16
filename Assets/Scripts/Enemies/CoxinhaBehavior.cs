using Managers;
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

        // public int enemyDamage = 1;
        private bool _exploding;

        [Header("Attack Variables")] [SerializeField]
        private GameObject explosaoCoxinha;

        [Header("Animation Variables")] [SerializeField]
        private Animator coxinhaAnimator;

        private static readonly int IsExploding = Animator.StringToHash("IsExploding");
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite sprite1;
        [SerializeField] private Sprite sprite2;
        [SerializeField] private Sprite sprite3;

        private void Start()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
            gameObject.GetComponent<EnemyDamageFlash>().DamageFlash();
            _currentHealth -= amount;
            if (_currentHealth <= 0)
                Destroy(gameObject);
        }

        private void OnBecameVisible()
        {
            _canMove = true;
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
            coxinhaAnimator.SetBool(IsRunning, false);
            coxinhaAnimator.SetBool(IsExploding, true);
            // if (coxinhaAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 &&
            //     !coxinhaAnimator.IsInTransition(0))
            // {
            Invoke(nameof(Sprite1), .2f);
            // }
        }

        private void Sprite1()
        {
            FindObjectOfType<AudioManager>().Play("CoxinhaRisada");
            _spriteRenderer.sprite = sprite1;
            Invoke(nameof(Sprite2), .2f);
        }

        private void Sprite2()
        {
            _spriteRenderer.sprite = sprite2;
            Invoke(nameof(Sprite3), .2f);
        }

        private void Sprite3()
        {
            _spriteRenderer.sprite = sprite3;
            Invoke(nameof(AtivaExplosao), .2f);
        }

        private void AtivaExplosao()
        {
            explosaoCoxinha.SetActive(true);
            Destroy(gameObject, .1f);
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
            // var targetPos = new Vector2(playerPos, enemyPos.y);
            var isFacingLeft = playerPos < enemyPos.x;

            if (isFacingLeft)
                _rb.AddForce(new Vector2(-1, 0f) * moveSpeed);
            else
            {
                _rb.AddForce(new Vector2(1, 0f) * moveSpeed);
            }

            if (Mathf.Abs(_rb.velocity.x) > 6f)
            {
                _rb.velocity = new Vector2(Mathf.Sign(_rb.velocity.x) * 6f, _rb.velocity.y);
            }

            // var position = Vector2.MoveTowards(enemyPos, targetPos, moveSpeed * Time.fixedDeltaTime);
            // _rb.MovePosition(position);
        }
    }
}