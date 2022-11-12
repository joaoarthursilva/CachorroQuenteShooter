using Player;
using UnityEngine;

namespace Enemies
{
    public class PastelMovement : Enemy
    {
        private Rigidbody2D _rb;

        [Header("Movement Variables")] [SerializeField]
        private float maxMoveSpeed = 11f;

        [SerializeField] private float movementAcceleration = 55;

        private Vector3 _position;
        public int startingHealth = 10;
        private int _currentHealth;
        public int enemyDamage = 5;
        private int _counter;

        public LayerMask playerLayer;
        public float raycastLength = 10f;
        private bool _hasSeenPlayer;
        private bool _hasBeenSeenByPlayer;


        [Header("Attack Variables")] [SerializeField]
        private float timeDamageDelay = .5f;

        private float _timeDamageDelayCounter;

        private void Start()
        {
            _rb = gameObject.GetComponent<Rigidbody2D>();
            _currentHealth = startingHealth;
            _hasBeenSeenByPlayer = false;
            _hasSeenPlayer = false;
            _counter = 0;
            _timeDamageDelayCounter = 0;
        }

        private void OnBecameVisible()
        {
            _hasBeenSeenByPlayer = true;
        }

        public override void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            if (_currentHealth <= 0)
                Destroy(gameObject);
        }

        private void Update()
        {
            _position = gameObject.transform.position;
            if (Physics2D.Raycast(_position, Vector2.left, raycastLength, playerLayer) ||
                Physics2D.Raycast(_position, Vector2.right, raycastLength, playerLayer))
            {
                // trigger animation here
                _hasSeenPlayer = true;
            }
        }

        private void OnCollisionStay2D(Collision2D col)
        {
            if (CanDealDamage()) _counter = 0;
            if (_counter != 0) return;
            if (!CanDealDamage() ||
                !col.gameObject.TryGetComponent(out PlayerHealth playerHealth))
                return;
            playerHealth.TakeDamage(enemyDamage);
            _timeDamageDelayCounter = timeDamageDelay;
            _counter++;
        }

        private bool CanDealDamage()
        {
            return _timeDamageDelayCounter <= 0;
        }

        private void FixedUpdate()
        {
            _timeDamageDelayCounter -= Time.deltaTime;
            if (_hasBeenSeenByPlayer && _hasSeenPlayer)
                Move();
        }

        private void Move()
        {
            _rb.AddForce(new Vector2(-1, 0f) * movementAcceleration);
            if (Mathf.Abs(_rb.velocity.x) > maxMoveSpeed)
                _rb.velocity = new Vector2(Mathf.Sign(_rb.velocity.x) * maxMoveSpeed, _rb.velocity.y);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            _position = gameObject.transform.position;
            Gizmos.DrawLine(_position, _position + Vector3.left * raycastLength);
            Gizmos.DrawLine(_position, _position + Vector3.right * raycastLength);
        }
    }
}