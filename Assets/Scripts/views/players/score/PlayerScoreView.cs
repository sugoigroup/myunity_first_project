using System;
using System.Collections;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlayerScoreView : MonoBehaviour
    {
   
        private TextMeshProUGUI textScore;
       

        private void Awake()
        { 
            textScore = GetComponent<TextMeshProUGUI>();
        }

        public void ScoreSet(int score)
        {
            textScore.text = "Score : " + score;
        }
    }
}