using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class ParticleAudioDestroyer : MonoBehaviour
    {
        private ParticleSystem particle;

        private void Awake()
        {
            particle = GetComponent<ParticleSystem>();
        }

        private void Update()
        {
            if (!particle.isPlaying)
            {
                  Destroy(gameObject);
            }
        }
    }
}