using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class BossHp : MonoBehaviour
    {
        [SerializeField] private float maxHp = 1000;
        private float currentHp;
        private SpriteRenderer spriteRenderer;
        private Boss boss;

        public float MaxHp => maxHp;
        public float CurrentHp => currentHp;

        private void Awake()
        {
            currentHp = maxHp;
            spriteRenderer = GetComponent<SpriteRenderer>();
            boss = GetComponent<Boss>();
        }

        public void TakeDamage(float damage)
        {
            currentHp -= damage;
            
            StopCoroutine("HitColorAnimation");
            StartCoroutine("HitColorAnimation");

            if (currentHp <= 0)
            {
                boss.OnDie();
            }
        }

        private IEnumerator HitColorAnimation()
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.05f);
            spriteRenderer.color = Color.white;
        }
    }
}