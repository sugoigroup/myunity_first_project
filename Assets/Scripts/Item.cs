﻿using System;
using UnityEngine;
using System.Collections;
using System.ComponentModel;
using DefaultNamespace;
using Random = UnityEngine.Random;

public enum ItemType { PowerUp = 0, Boom, Hp}
public class Item : MonoBehaviour
{
    [SerializeField] private ItemType itemType ;
    private Movement2D movement2D;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();

        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);
        
        movement2D.MoveTo(new Vector3(x, y, 0));
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            UseItem(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void UseItem(GameObject player)
    {
        switch (itemType)
        {
            case ItemType.PowerUp:
                player.GetComponent<Weapon>().AttackLevel++;
                break;
            case ItemType.Boom:
                player.GetComponent<Weapon>().BoomCount++;
                break;
            case ItemType.Hp:
                player.GetComponent<PlayerHp>().CurrentHp += 2;
                break;
        }
    }
}

