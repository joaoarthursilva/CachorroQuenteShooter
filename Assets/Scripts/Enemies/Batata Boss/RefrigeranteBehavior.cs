using Player;
using UnityEngine;

namespace Enemies.Batata_Boss
{
    public class RefrigeranteBehavior : MonoBehaviour
    {
        public int enemyDamage;
        private void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log(col);
            if (col.gameObject.TryGetComponent(out PlayerHealth playerHealth))
                playerHealth.TakeDamage(enemyDamage);
        }
    }
}