﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().OnDie();
            Destroy(gameObject);
        }
    }
}
