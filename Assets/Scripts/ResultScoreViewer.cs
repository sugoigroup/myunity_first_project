using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ResultScoreViewer : MonoBehaviour
    {
        private TextMeshProUGUI textResultScore;

        private void Awake()
        {
            textResultScore = GetComponent<TextMeshProUGUI>();
            int score = PlayerPrefs.GetInt("Score");
            textResultScore.text = "Result Score " + score;
        }
    }
}