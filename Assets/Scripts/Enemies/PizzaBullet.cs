using Player;
using UnityEngine;

namespace Enemies
{
    public class PizzaBullet : MonoBehaviour
    {
        public float moveSpeed = 17f;
        private Rigidbody2D _rb;
        private Transform _target;
        private Vector2 _moveDirection;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            _moveDirection = (_target.transform.position - transform.position).normalized * moveSpeed;
            _rb.AddForce(new Vector2(_moveDirection.x, _moveDirection.y), ForceMode2D.Impulse);
            // _rb.velocity = new Vector2(_moveDirection.x, _moveDirection.y);
            Destroy(gameObject, 4f);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
                col.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}