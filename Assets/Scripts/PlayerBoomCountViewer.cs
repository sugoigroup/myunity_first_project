using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlayerBoomCountViewer : MonoBehaviour
    {
        [SerializeField] private Weapon weapon ;
        private TextMeshProUGUI textBoomCount;

        private void Awake()
        {
            textBoomCount = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            textBoomCount.text = "x " + weapon.BoomCount;
        }
    }
}