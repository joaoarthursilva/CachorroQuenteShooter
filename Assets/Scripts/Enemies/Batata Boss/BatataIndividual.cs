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
            if (a == 0)
                sprite.flipX = true;
            else if (a == 1)
                sprite.flipX = false;
        }
    }
}