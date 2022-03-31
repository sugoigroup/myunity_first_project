
using System;
using UnityEngine;
using System.Collections;
using DefaultNamespace;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.valueobject;
using UniRx;
using UniRx.Triggers;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = -1;
    [SerializeField] private int scorePoint = 100;
    [SerializeField] private GameObject[] itemPrefabs;
    

    [SerializeField] private GameObject explosionPrefab;

    private EnemyHpViewController enemyHpViewController;

    public void setEnemyHpViewController(EnemyHpViewController enemyHpViewController)
    {
        this.enemyHpViewController = enemyHpViewController;
    }
    
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        MessageBroker.Default.Receive<BombExplodeByOutside>().Subscribe(whoShooted =>
        {
            OnDie(whoShooted.owenerGameObjectId);
        }).AddTo(this);
        
        this.OnCollisionEnter2DAsObservable()
            .Subscribe(collision => {
                print(collision.gameObject.tag);
            }).AddTo(this);
    }

    private void Start()
    {
        enemyHpViewController.IsDie.Where(x => x).Subscribe(value =>
        {
            OnDie(enemyHpViewController.LastFromGameObjectId());
        }).AddTo(this);
        enemyHpViewController.IsDamaged.Subscribe (value =>
            {
                StopCoroutine("HitColorAnimation");
                StartCoroutine("HitColorAnimation");
            }
        ).AddTo(this);
        



    }
    

    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);

        spriteRenderer.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            var playerController = collision.GetComponent<PlayerController>();
            playerController.TakeDamage(damage);
            
            OnDie(collision.gameObject.GetInstanceID());
        }
    }

    public void OnDie(int fromGameObjectId)
    {
        MessageBroker.Default.Publish(new ScorePlusByOutside(fromGameObjectId, scorePoint));
        
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        SpawnItem();
        
        Destroy(gameObject);
    }

    private void SpawnItem()
    {
        int spawnItem = Random.Range(0, 100);
        if (spawnItem < 10)
        {
            Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
        } else if (spawnItem < 15)
        {
            Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
        }else if (spawnItem < 30)
        {
            Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHpViewController.TakeDamage(damage);
    }
}
