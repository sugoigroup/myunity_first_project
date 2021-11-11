using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlayerScoreViewer : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController ;
        private TextMeshProUGUI textScore;

        private void Awake()
        {
            textScore = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            textScore.text = "Score : " + playerController.Score;
        }
    }
}