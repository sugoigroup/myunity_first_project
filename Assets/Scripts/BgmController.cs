using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public enum BgmType { Start = 0, Boss }
    public class BgmController : MonoBehaviour
    {
        [SerializeField] private AudioClip[] bgmClips;
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            
        }

        public void ChangeBgm(BgmType index)
        {
            audioSource.Stop();

            audioSource.clip = bgmClips[(int)index];
            audioSource.Play();
        }
    }
}