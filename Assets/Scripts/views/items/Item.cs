using System;
using UnityEngine;
using System.Collections;
using System.ComponentModel;
using DefaultNamespace;
using DefaultNamespace.domain.valueobject;
using UniRx;
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
        var ownerGameObjectId = player.GetInstanceID();
        var fromGameObjectId = gameObject.GetInstanceID();
        switch (itemType)
        {
            case ItemType.PowerUp:
                player.GetComponent<WeaponMissile>().AttackLevel++;
                break;
            case ItemType.Boom:
                MessageBroker.Default.Publish(new BombPlusByOutside(ownerGameObjectId, 1));
                break;
            case ItemType.Hp:
                MessageBroker.Default.Publish(new HpPlusByOutside(ownerGameObjectId, fromGameObjectId, 2));
                break;
        }
    }
}

