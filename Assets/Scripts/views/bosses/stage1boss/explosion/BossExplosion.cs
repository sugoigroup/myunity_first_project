using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class BossExplosion : MonoBehaviour
    {
        private string sceneName;

        public void Setup( string sceneName)
        {
            this.sceneName = sceneName;
        }

        private void OnDestroy()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}