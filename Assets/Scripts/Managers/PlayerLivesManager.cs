using System;
using UnityEngine;

namespace Managers
{
    public class PlayerLivesManager : MonoBehaviour
    {
        private int _currentPlayerLives;

        public void IncreasePlayerLives()
        {
            _currentPlayerLives++;
        }

        public void DecreasePlayerLives()
        {
            _currentPlayerLives--;
        }

        public void SetCurrentPlayerLives(int livesAmount)
        {
            _currentPlayerLives = livesAmount;
        }

        public int GetPlayerLives()
        {
            return _currentPlayerLives;
        }
    }
}