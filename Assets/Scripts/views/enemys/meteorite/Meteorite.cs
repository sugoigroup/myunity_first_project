using System;
using UnityEngine;
using System.Collections;
using DefaultNamespace;
using DefaultNamespace.domain.valueobject;
using UniRx;

public class Meteorite : MonoBehaviour
{
    [SerializeField] private int damage =-1;

    [SerializeField] private GameObject explosionPrefab;

    private void Awake()
    {
        
        MessageBroker.Default.Receive<BombExplodeByOutside>().Subscribe(whoShooted =>
        {
            OnDie();
        }).AddTo(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {  
            MessageBroker.Default.Publish(new HpPlusByOutside(collision.gameObject.GetInstanceID(), gameObject.GetInstanceID(), damage));
            OnDie();
        }
    }

    public void OnDie()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
