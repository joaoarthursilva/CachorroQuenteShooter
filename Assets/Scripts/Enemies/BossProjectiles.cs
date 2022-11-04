using Player;
using UnityEngine;

namespace Enemies
{
    public class BossProjectiles : MonoBehaviour
    {
        private Rigidbody2D _rb;
        public float velocidade = 10;

        [Header("Attack Variables")] [SerializeField]
        private float timeDamageDelay = .5f;

        private int _counter;
        private float _timeDamageDelayCounter;

        private void Start()
        {
            _counter = 0;
            _timeDamageDelayCounter = 0;
            _rb = gameObject.GetComponent<Rigidbody2D>();
            var moveDirection = new Vector2(-10, 0);
            _rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            if (CanDealDamage()) _counter = 0;
            if (_counter != 0) return;
            if (!CanDealDamage() ||
                !col.gameObject.TryGetComponent(out PlayerHealth playerHealth))
                return;
            playerHealth.TakeDamage(1);
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
        }
    }
}