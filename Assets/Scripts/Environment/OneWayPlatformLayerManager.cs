using UnityEngine;

namespace Environment
{
    public class OneWayPlatformLayerManager : MonoBehaviour
    {
        public GameObject platform;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Player")) return;
            platform.layer = 3;
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Player")) return;
            platform.layer = 0;
        }
    }
}