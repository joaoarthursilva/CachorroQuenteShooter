using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (!_playerHealth.IsDead()) return;
            if (SceneManager.GetActiveScene().name == "Boss")
                SceneManager.LoadScene("Boss");
            _playerHealth.Spawn();
        }
    }
}
