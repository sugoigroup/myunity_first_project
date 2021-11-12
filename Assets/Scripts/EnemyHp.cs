using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyHp : MonoBehaviour
    {
        [SerializeField] private float maxHp = 4;
        private float currentHp;
        private SpriteRenderer spriteRenderer;
        private Enemy enemy;
        
        public float MaxHp => maxHp;
        public float CurrentHp => currentHp;
        

        private void Awake()
        {
            currentHp = maxHp;
            spriteRenderer = GetComponent<SpriteRenderer>();
            enemy = GetComponent<Enemy>();
        }

        public void TakeDamage(float damage)
        {
            currentHp -= damage;
            
            StopCoroutine("HitColorAnimation");
            StartCoroutine("HitColorAnimation");

            if (currentHp <= 0)
            {
                enemy.OnDie();
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