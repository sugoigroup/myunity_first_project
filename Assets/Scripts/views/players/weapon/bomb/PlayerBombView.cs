using System;
using UnityEngine;
using System.Collections;
using DefaultNamespace;
using DefaultNamespace.domain.valueobject;
using UniRx;

public class PlayerBombView : MonoBehaviour
{
    
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private AudioClip bombAudio;
    private AudioSource audioSource;
    
    
    private int damage = 100;
    private float bombDelay = 0.5f;
    
    private Animator animator;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
            
        audioSource = GetComponent<AudioSource>();
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }

    public void setBombDelay(float delay)
    {
        this.bombDelay = delay;
    }

    public void setTrigger()
    {
        
        animator.SetTrigger("onBomb");
    }

    public void playBombAudio()
    {
        audioSource.clip = bombAudio;
        audioSource.Play();
    }

    public float getCurveEvaluate(float percent)
    {
        return curve.Evaluate(percent);
    }
}
