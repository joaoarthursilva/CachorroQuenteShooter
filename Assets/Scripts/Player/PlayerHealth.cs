using System;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int startingHealth = 6;
        private int _currentHealth;
        [SerializeField] private Transform startingSpawnPoint;
        private Vector3 _currentSpawnPoint;
        [SerializeField] private Canvas youDiedScreen;
        [SerializeField] private int totalLives;
        private bool _isDead;

        [SerializeField] private TextMeshProUGUI livesText;
        [SerializeField] private TextMeshProUGUI youDiedText;
        [SerializeField] private TextMeshProUGUI respawnText;
        private PlayerLivesManager _playerLivesManager;
        private bool _runUpdateRespawnOnce = false;

        private void Start()
        {
            _runUpdateRespawnOnce = false;
            totalLives = 3;
            _currentSpawnPoint = startingSpawnPoint.position;
            _playerLivesManager = GameObject.FindWithTag("PlayerLivesManager").GetComponent<PlayerLivesManager>();
            if (_playerLivesManager.GetPlayerLives() == 0)
                _playerLivesManager.SetCurrentPlayerLives(totalLives);
            Spawn();
        }

        private void Update()
        {
            if (SceneManager.GetActiveScene().name == "Boss" && !_runUpdateRespawnOnce)
            {
                _currentSpawnPoint = new Vector3(0, 0, 0);
                _runUpdateRespawnOnce = true;
                Spawn();
            }

            livesText.text = "x" + _playerLivesManager.GetPlayerLives();
        }

        public void SetSpawnPoint(Transform spawnpoint)
        {
            _currentSpawnPoint = spawnpoint.position;
        }

        public void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            if (_currentHealth <= 0)
            {
                _playerLivesManager.DecreasePlayerLives();
                Die();
            }
        }

        public int GetCurrentHealth()
        {
            return _currentHealth;
        }

        public void RegenerateHealth(int amount)
        {
            _currentHealth += amount;
            _currentHealth = Math.Min(_currentHealth, startingHealth);
        }

        private void Die()
        {
            _isDead = true;
            youDiedScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
            youDiedText.text = _playerLivesManager.GetPlayerLives() <= 0 ? "Game Over" : "You Died";
            respawnText.text =
                _playerLivesManager.GetPlayerLives() <= 0 ? "Click anywhere to restart" : "Click anywhere to respawn";
        }

        public bool IsDead()
        {
            return _isDead;
        }

        public void Spawn()
        {
            Time.timeScale = 1;
            gameObject.transform.position = _currentSpawnPoint;
            _isDead = false;
            youDiedScreen.gameObject.SetActive(false);
            _currentHealth = startingHealth;
        }
    }
}