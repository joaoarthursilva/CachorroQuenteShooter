using UnityEngine;

namespace Environment
{
    public class IceBehavior : MonoBehaviour
    {
        public float timeToMelt = 1.5f;
        // public Animator geloAnim;
        public bool canMove;
        public float moveSpeed;
        private void FixedUpdate()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Player")) return;
            //começa a destruir
            //comeca animacao
            Destroy(gameObject, timeToMelt);
        }
    }
}