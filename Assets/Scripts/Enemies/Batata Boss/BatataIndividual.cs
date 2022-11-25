using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Batata_Boss
{
    public class BatataIndividual : MonoBehaviour
    {
        private void Awake()
        {
            var sprite = gameObject.GetComponent<SpriteRenderer>();
            var a = Random.Range(0, 2);
            sprite.flipX = a switch
            {
                0 => true,
                1 => false,
                _ => sprite.flipX
            };
        }
    }
}