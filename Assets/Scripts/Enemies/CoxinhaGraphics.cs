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
            transform.localScale = _player.position.x > _coxinhaTransform.position.x
                ? new Vector3(-1f, 1f, 1f)
                : new Vector3(1f, 1f, 1f);
        }
    }
}