using UnityEngine;

namespace Managers
{
    public class DontDestroy : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

    }
}