using UnityEngine;

namespace Enemies
{
    public class CoxinhaGraphics : MonoBehaviour
    {
        private Transform _coxinhaTransform;
        private Transform _player;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player").GetComponent<Transform>();
            _coxinhaTransform = gameObject.GetComponent<Transform>();
        }

        private void Update()
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = _player.position.x > _coxinhaTransform.position.x;
        }
    }
}