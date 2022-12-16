using Managers;
using Player;
using UnityEngine;

namespace Enemies
{
    public class CoxinhaExplosion : MonoBehaviour
    {
        // public int explosionDamage = 2;
        [SerializeField] private Sprite explosionSprite;
        [SerializeField] private GameObject coxinha;
        [SerializeField] private float raioExplosao = 2.9f;

        private int _counter;

        private void Start()
        {
            FindObjectOfType<AudioManager>().Play("CoxinhaExplosion");
            coxinha.GetComponent<SpriteRenderer>().sprite = explosionSprite;
            gameObject.GetComponent<CircleCollider2D>().radius = raioExplosao;
            _counter = 0;
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            if (_counter != 0) return;

            if (!col.gameObject.TryGetComponent(out PlayerHealth playerHealth)) return;
            playerHealth.TakeDamage(2);
            _counter++;
        }
    }
}