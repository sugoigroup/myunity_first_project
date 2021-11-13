using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class EnemyProjectile : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private GameObject explosionPrefab;

        public void OnDie()
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerHp>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}