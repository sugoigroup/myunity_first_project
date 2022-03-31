using System;
using System.Collections;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlayerHpView : MonoBehaviour
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