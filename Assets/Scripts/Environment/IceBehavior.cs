using System;
using UnityEngine;

namespace Environment
{
    public class IceBehavior : MonoBehaviour
    {
        public float timeToMelt = 1.5f;

        [SerializeField] private GameObject geloSprite;

        // public Animator geloAnim;


        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Player")) return;
            //começa a destruir
            //comeca animacao
            Invoke(nameof(SomeGelo), timeToMelt);
        }

        private void SomeGelo()
        {
            geloSprite.SetActive(false);
            Invoke(nameof(RespawnGelo), timeToMelt * 2);
        }

        private void RespawnGelo()
        {
            geloSprite.SetActive(true);
        }
    }
}