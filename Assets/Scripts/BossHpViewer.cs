using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class BossHpViewer : MonoBehaviour
    {
        [SerializeField] private BossHp bossHp;
        private Slider sliderHp;

        private void Awake()
        {
            sliderHp = GetComponent<Slider>();
        }

        private void Update()
        {
            sliderHp.value = bossHp.CurrentHp / bossHp.MaxHp;
        }
    }
}