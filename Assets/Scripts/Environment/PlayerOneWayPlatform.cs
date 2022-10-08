using System.Collections;
using UnityEngine;

namespace Environment
{
    public class PlayerOneWayPlatform : MonoBehaviour
    {
        private GameObject _currentOneWayPlatform;
        private CapsuleCollider2D _playerCollider;

        private void Start()
        {
            _playerCollider = GameObject.FindWithTag("Player").GetComponent<CapsuleCollider2D>();
        }

        private void Update()
        {
            if (_currentOneWayPlatform == null) return;
            /* if (Input.GetAxis("Vertical") <= -.5f)
            {
                StartCoroutine(DisableCollision());
            } */
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.CompareTag("OneWayPlatform")) return;
            _currentOneWayPlatform = col.gameObject;
        }
        private void OnCollisionExit2D(Collision2D col)
        {
            if (!col.gameObject.CompareTag("OneWayPlatform")) return;
            _currentOneWayPlatform = null;
        }

        private IEnumerator DisableCollision()
        {
            BoxCollider2D platformCollider = _currentOneWayPlatform.GetComponent<BoxCollider2D>();
        
            Physics2D.IgnoreCollision(_playerCollider, platformCollider);

            yield return new WaitForSeconds(.25f);
            Physics2D.IgnoreCollision(_playerCollider, platformCollider, false);
        }
    }
}