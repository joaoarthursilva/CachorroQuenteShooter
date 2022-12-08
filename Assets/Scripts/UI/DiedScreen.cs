using System.Collections.Generic;
using System.Linq;
using Managers;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class DiedScreen : MonoBehaviour
    {
        private PlayerHealth _playerHealth;
        private PlayerLivesManager _playerLivesManager;

        private void Start()
        {
            _playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
            _playerLivesManager = GameObject.FindWithTag("PlayerLivesManager").GetComponent<PlayerLivesManager>();
        }

        public void Respawn()
        {
            if (!_playerHealth.IsDead()) return;
            var currentScene = SceneManager.GetActiveScene().name;
            var sceneName = "";
            var lives = _playerLivesManager.GetPlayerLives();
            Debug.Log(lives);


            switch (currentScene)
            {
                case "Boss" when lives <= 0:
                    ReverseDontDestroy();
                    sceneName = "MainMenu";
                    break;
                case "SampleScene" when lives <= 0:
                    ReverseDontDestroy();
                    sceneName = "MainMenu";
                    break;
                case "Boss" when lives > 0:
                    SceneManager.LoadScene(currentScene);
                    break;
            }

            if (lives <= 0)
            {
                SceneManager.LoadScene(sceneName);
            }

            _playerHealth.Spawn();
        }

        private void ReverseDontDestroy()
        {
            foreach (var go in GetDontDestroyOnLoadObjects())
            {
                SceneManager.MoveGameObjectToScene(go, SceneManager.GetActiveScene());
            }
        }

        private static List<GameObject> GetDontDestroyOnLoadObjects()
        {
            var rootGameObjectsExceptDontDestroyOnLoad = new List<GameObject>();
            for (var i = 0; i < SceneManager.sceneCount; i++)
            {
                rootGameObjectsExceptDontDestroyOnLoad.AddRange(SceneManager.GetSceneAt(i).GetRootGameObjects());
            }

            var rootGameObjects = new List<GameObject>();
            var allTransforms = Resources.FindObjectsOfTypeAll<Transform>();
            foreach (var t in allTransforms)
            {
                var root = t.root;
                if (root.hideFlags == HideFlags.None && !rootGameObjects.Contains(root.gameObject))
                {
                    rootGameObjects.Add(root.gameObject);
                }
            }

            return rootGameObjects.Where(t => !rootGameObjectsExceptDontDestroyOnLoad.Contains(t)).ToList();
        }
    }
}