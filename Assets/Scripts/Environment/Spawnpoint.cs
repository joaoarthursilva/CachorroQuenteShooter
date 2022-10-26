using Player;
using UnityEngine;

namespace Environment
{
    public class Spawnpoint : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().SetSpawnPoint(gameObject.transform);
        }
    }
}
