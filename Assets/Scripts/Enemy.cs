using UnityEngine;
using System.Collections;
using DefaultNamespace;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHp>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
