using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class EndOfLevelManager : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Player"))
                return;
            // run cutscene
            SceneManager.LoadScene("Boss");
        }
    }
}