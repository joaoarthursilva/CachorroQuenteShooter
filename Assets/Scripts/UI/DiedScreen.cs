using Player;
using UnityEngine;

namespace UI
{
    public class DiedScreen : MonoBehaviour
    {
        private PlayerHealth _playerHealth;
        private void Start()
        {
            _playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        }

        public void Respawn()
        {
            if (_playerHealth.IsDead())
            {
                _playerHealth.Spawn();
            }
        }
    }
}
