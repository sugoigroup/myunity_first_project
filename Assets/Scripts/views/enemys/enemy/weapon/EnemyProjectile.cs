using System;
using DefaultNamespace.domain.valueobject;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class EnemyProjectile : MonoBehaviour
    {
        [SerializeField] private int damage = -1;
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
                var playerController = collision.GetComponent<PlayerController>();
                playerController.TakeDamage(damage);
                
                MessageBroker.Default.Publish(new HpPlusByOutside(playerController.GetInstanceID(), gameObject.GetInstanceID(),damage));
                Destroy(gameObject);
            }
        }
    }
}