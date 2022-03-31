using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlayerBombCountView : MonoBehaviour
    {
        private TextMeshProUGUI textBoomCount;

        private void Awake()
        {
            textBoomCount = GetComponent<TextMeshProUGUI>();
        }
        
        public void SetBombCount(int bombCount)
        {
            textBoomCount.text = "x " + bombCount;
        }
    }
}