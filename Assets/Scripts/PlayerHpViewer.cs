using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlayerHpViewer : MonoBehaviour
    {
        [SerializeField] private PlayerHp playerHp ;
        private Slider sliderHp;

        private void Awake()
        {
            sliderHp = GetComponent<Slider>();
        }

        private void Update()
        {
            sliderHp.value = playerHp.CurrentHp / playerHp.MaxHp;
        }
    }
}