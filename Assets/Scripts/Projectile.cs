using UnityEngine;
using System.Collections;
using DefaultNamespace;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //collision.GetComponent<Enemy>().OnDie();
            collision.GetComponent<EnemyHp>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
