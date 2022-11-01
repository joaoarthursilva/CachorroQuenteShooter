using Player;
using UnityEngine;

namespace Environment
{
    public class ForaDoMapa : MonoBehaviour
    {
        private float _timeDamageDelayCounter;
        public float timeDamageDelay = .1f;

        private void OnTriggerStay2D(Collider2D col)
        {
            if (!CanDealDamage() ||
                !col.gameObject.TryGetComponent(out PlayerHealth playerHealth))
                return;
            playerHealth.TakeDamage(1);
            _timeDamageDelayCounter = timeDamageDelay;
        }

        private bool CanDealDamage()
        {
            return _timeDamageDelayCounter <= 0;
        }

        private void FixedUpdate()
        {
            _timeDamageDelayCounter -= Time.deltaTime;
        }
    }
}