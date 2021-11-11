using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerHp : MonoBehaviour
    {
        [SerializeField] private float maxHp = 10;
        private float currentHp;
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            currentHp = maxHp;
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void TakeDamage(float damage)
        {
            currentHp -= damage;
            
            StopCoroutine("HitColorAnimation");
            StartCoroutine("HitColorAnimation");

            if (currentHp <= 0)
            {
                print("HP Die");
            }
        }

        private IEnumerator HitColorAnimation()
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);

            spriteRenderer.color = Color.white;
        }
    }
}