using System;
using UnityEngine;
using System.Collections;
using DefaultNamespace;
using DefaultNamespace.domain.valueobject;
using UniRx;

public class WeaponMissile : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float attackRate = 0.1f;

    [SerializeField] private int maxAttackLevel = 3;
    private int attackLevel = 1;
    private int _owenerGameObjectId;

    private AudioSource audioSource;

    [SerializeField] private GameObject boomPrefab;
    private int BoomCount = 5;


    public int AttackLevel
    {
        set => attackLevel = Mathf.Clamp(value, 1, maxAttackLevel);
        get => attackLevel;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        MessageBroker.Default.Publish(new BombPlusByOutside(_owenerGameObjectId, BoomCount));
        AsyncMessageBroker.Default.PublishAsync(new BombUseByOutside(_owenerGameObjectId)).Subscribe(_ =>
        {
        }).AddTo(this);
        
        MessageBroker.Default.Receive<BombGetCountReturnByOutside>()
            .Where(x => x.owenerGameObjectId == _owenerGameObjectId)
            .Subscribe(newBomb =>
            {
                this.BoomCount = newBomb.bombCount;
            }).AddTo(this);
    }


    public void StartBoom()
    {
        if (BoomCount > 0)
        {
            AsyncMessageBroker.Default.PublishAsync(new BombUseByOutside(_owenerGameObjectId)).Subscribe(_ =>
            {
                GameObject bombGameObject = Instantiate(boomPrefab, transform.position, Quaternion.identity);
                bombGameObject.GetComponent<PlayerBombViewController>().SetOwenerGameObjectId(_owenerGameObjectId);
            }).AddTo(this);
        }
    }

    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack()
    {
        while (true)
        {
            // GameObject g = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            // g.GetComponent<Movement2D>().MoveTo(new Vector3(0.2f, 1 ,0));
            AttackByLevel();
            audioSource.Play();
            yield return new WaitForSeconds(attackRate);
        }
    }

    private void AttackByLevel()
    {
        GameObject missile;
        switch (attackLevel)
        {
            case 1:
                missile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                missile.GetComponent<ProjectileViewController>().SetOwenerGameObjectId(_owenerGameObjectId);
                missile.SetActive(true);
                break;
            case 2:
                missile = Instantiate(projectilePrefab, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                missile.GetComponent<ProjectileViewController>().SetOwenerGameObjectId(_owenerGameObjectId);
                missile.SetActive(true);
                missile = Instantiate(projectilePrefab, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                missile.GetComponent<ProjectileViewController>().SetOwenerGameObjectId(_owenerGameObjectId);
                missile.SetActive(true);
                break;
            case 3:
                missile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                missile.GetComponent<ProjectileViewController>().SetOwenerGameObjectId(_owenerGameObjectId);
                missile.SetActive(true);
                missile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                missile.GetComponent<Movement2D>().MoveTo(new Vector3(-0.2f, 1, 0));
                missile.GetComponent<ProjectileViewController>().SetOwenerGameObjectId(_owenerGameObjectId);
                missile.SetActive(true);
                missile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                missile.GetComponent<Movement2D>().MoveTo(new Vector3(0.2f, 1, 0));
                missile.GetComponent<ProjectileViewController>().SetOwenerGameObjectId(_owenerGameObjectId);
                missile.SetActive(true);
                break;
        }
    }

    public void SetOwenerGameObjectId(int getInstanceID)
    {
        _owenerGameObjectId = getInstanceID;
    }
}