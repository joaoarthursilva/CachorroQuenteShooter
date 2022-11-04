using Player;
using UnityEngine;

namespace Environment
{
    public class Spawnpoint : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.TryGetComponent(out PlayerHealth playerHealth))
                return;
            playerHealth.SetSpawnPoint(gameObject.transform);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}