using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class BossExplosion : MonoBehaviour
    {
        private PlayerController playerController;
        private string sceneName;

        public void Setup(PlayerController playerController, string sceneName)
        {
            this.playerController = playerController;
            this.sceneName = sceneName;
        }

        private void OnDestroy()
        {
            playerController.Score += 10000;
            PlayerPrefs.SetInt("Score", playerController.Score);
            SceneManager.LoadScene(sceneName);
        }
    }
}