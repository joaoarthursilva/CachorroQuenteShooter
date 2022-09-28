using Pathfinding;
using UnityEngine;

namespace Enemies
{
    public class EnemyGraphics : MonoBehaviour
    {
        public AIPath aiPath;
        public Rigidbody2D rb2d;
        private void Update()
        {
            if (aiPath.desiredVelocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(-1f, 0.6f, 1f);
            }
            else if (aiPath.desiredVelocity.x <= -0.01f)
            {
                transform.localScale = new Vector3(1f, 0.6f, 1f);
            }
        }
    }
}