using UnityEngine;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public abstract void TakeDamage(int amount);
    }
}