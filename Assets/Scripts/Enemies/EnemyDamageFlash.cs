using UnityEngine;

namespace Enemies
{
    public class EnemyDamageFlash : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;

        private SpriteRenderer _spriteRenderer;
        private Color _defaultColor;
        [SerializeField] private float flashTime = .2f;

        private void Start()
        {
            _defaultColor = sprite.color;
        }

        public void DamageFlash()
        {
            sprite.color = Color.red;
            Invoke(nameof(ResetColorFlash), flashTime);
        }

        private void ResetColorFlash()
        {
            sprite.color = _defaultColor;
        }
    }
}