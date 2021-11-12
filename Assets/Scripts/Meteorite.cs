using System;
using UnityEngine;
using System.Collections;
using DefaultNamespace;

public class Meteorite : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    [SerializeField] private GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHp>().TakeDamage(damage);
            OnDie();
        }
    }

    public void OnDie()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
