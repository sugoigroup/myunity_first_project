﻿using System;
using UnityEngine;
using System.Collections;
using DefaultNamespace;

public class PlayerBoom : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;

    [SerializeField] private AudioClip boomAudio;
    [SerializeField] private int damage = 100;
    
    private float boomDelay = 0.5f;
    private Animator animator;
    private AudioSource audioSource;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        StartCoroutine("MoveToCenter");
    }

    private IEnumerator MoveToCenter()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Vector3.zero;
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / boomDelay;
            
            transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percent));
            yield return null;
        }

        animator.SetTrigger("onBoom");
        audioSource.clip = boomAudio;
        audioSource.Play();

    }

    public void onBoom()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] meteorites = GameObject.FindGameObjectsWithTag("Meteorite");

        for (int i = 0; i < enemys.Length; ++i)
        {
            enemys[i].GetComponent<Enemy>().OnDie();
        }
        for (int i = 0; i < meteorites.Length; ++i)
        {
            meteorites[i].GetComponent<Meteorite>().OnDie();
        }

        GameObject[] projectile = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        for (int i = 0; i < projectile.Length; ++i)
        {
            projectile[i].GetComponent<EnemyProjectile>().OnDie();
        }

        GameObject boss = GameObject.FindWithTag("Boss");
        if(boss != null)
        {
            boss.GetComponent<BossHp>().TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
