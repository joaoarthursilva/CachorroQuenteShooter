using UnityEngine;

namespace Managers
{
    public class BackgroundManager : MonoBehaviour
    {
        // private float _length, _startPos;
        public Camera cam;
        public float effect;

        private void Start()
        {
            // _startPos = transform.position.x;
            // _length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        private void FixedUpdate()
        {
            var position = cam.transform.position;
            var temp = (position.x * 1 - effect);
            var dist = (position.x * effect);

            var transform1 = transform;
            var position1 = transform1.position;
            // position1 = new Vector3(_startPos + dist, position1.y, position1.z);
            transform1.position = position1;
            // if (temp > _startPos + _length) _startPos += _length;
            // else if (temp < _startPos - _length) _startPos -= _length;
        }
    }
}