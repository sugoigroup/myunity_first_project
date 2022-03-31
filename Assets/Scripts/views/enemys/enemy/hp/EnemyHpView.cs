using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class EnemyHpView : MonoBehaviour
    {
        private Slider sliderHp;

        private void Awake()
        {
            sliderHp = GetComponent<Slider>();
        }
        public void HpPercentageSet(float value)
        {
            sliderHp.value = value;
        }
    }
}