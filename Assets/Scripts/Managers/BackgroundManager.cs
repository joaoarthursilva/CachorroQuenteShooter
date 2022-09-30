using UnityEngine;

namespace Managers
{
    public class BackgroundManager : MonoBehaviour
    {
        private float _length, _startPos;
        public Camera cam;
        public float effect;

        private void Start()
        {
            _startPos = transform.position.x;
            _length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        private void FixedUpdate()
        {
            var dist = (cam.transform.position.x * effect);

            var transform1 = transform;
            transform1.position = new Vector3(_startPos + dist, 0, transform1.position.z);
        }
    }
}