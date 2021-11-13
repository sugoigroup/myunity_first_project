using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class EnemyHpViewer : MonoBehaviour
    {
        private EnemyHp enemyHp ;
        private Slider sliderHp;

        public void Setup(EnemyHp enemyHp)
        {
            this.enemyHp = enemyHp;
            sliderHp = GetComponent<Slider>();
        }

        private void Update()
        {
            sliderHp.value = enemyHp.CurrentHp / enemyHp.MaxHp;
        }
    }
}