using Managers;
using Player;
using UnityEngine;

public class OneUp : MonoBehaviour
{
    private PlayerLivesManager _playerLivesManager;

    private void Start()
    {
        _playerLivesManager = GameObject.FindWithTag("PlayerLivesManager").GetComponent<PlayerLivesManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        _playerLivesManager.IncreasePlayerLives();
        gameObject.SetActive(false);
    }
}