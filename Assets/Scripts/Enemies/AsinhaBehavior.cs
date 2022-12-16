using Pathfinding;
using Player;
using UnityEngine;

namespace Enemies
{
    public class AsinhaBehavior : Enemy
    {
        private int _counter;
        private Transform _target;
        public float speed = 300f;
        public float nextWaypointDistance = 3f;
        private Path _path;
        private int _currentWaypoint;
        private Seeker _seeker;
        private Rigidbody2D _rb;

        public float repeatRate = .5f;

        // private Transform _transform;
        private bool _canMove;

        public int startingHealth = 10;
        private int _currentHealth;
        public int enemyDamage = 5;

        [Header("Attack Variables")] [SerializeField]
        private float timeDamageDelay = .5f;

        private float _timeDamageDelayCounter;

        private void Start()
        {
            _target = GameObject.FindWithTag("Player").transform;
            _currentHealth = startingHealth;
            // _transform = gameObject.GetComponent<Transform>();
            _canMove = false;
            _seeker = GetComponent<Seeker>();
            _rb = GetComponent<Rigidbody2D>();
            _target = GameObject.FindWithTag("Player").transform;
            _counter = 0;
            InvokeRepeating(nameof(UpdatePath), 0f, repeatRate);
        }

        public override void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            if (_currentHealth <= 0)
                Destroy(gameObject);
        }

        private void UpdatePath()
        {
            if (_seeker.IsDone())
                _seeker.StartPath(_rb.position, _target.position, OnPathComplete);
        }

        private void OnPathComplete(Path p)
        {
            if (p.error) return;

            _path = p;
            _currentWaypoint = 0;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Player"))
                return;
            TakeDamage(_currentHealth);
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

        private void OnBecameVisible()
        {
            _canMove = true;
        }

        // private void Update()
        // {
        // gameObject.GetComponent<SpriteRenderer>().flipX = !(_target.position.x > _transform.position.x);
        // }

        private void FixedUpdate()
        {
            _timeDamageDelayCounter -= Time.deltaTime;
            if (_canMove) Movement();
        }

        private void Movement()
        {
            if (_path == null) return;
            if (_currentWaypoint >= _path.vectorPath.Count)
            {
                return;
            }

            var direction = ((Vector2) _path.vectorPath[_currentWaypoint] - _rb.position).normalized;
            var force = direction * (speed * Time.deltaTime);

            _rb.AddForce(force);

            var distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                _currentWaypoint++;
            }
        }
    }
}