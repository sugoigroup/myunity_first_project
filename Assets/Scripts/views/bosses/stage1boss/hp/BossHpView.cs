using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class BossHpView : MonoBehaviour
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