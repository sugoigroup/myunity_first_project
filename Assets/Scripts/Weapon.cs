using System;
using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float attackRate = 0.1f;

    private int attackLevel = 1;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
        switch (attackLevel)
        {
            case 1:
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(projectilePrefab, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                Instantiate(projectilePrefab, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
            case 3:
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                Instantiate(projectilePrefab, transform.position, Quaternion.identity)
                    .GetComponent<Movement2D>()
                    .MoveTo(new Vector3(-0.2f, 1, 0));
                Instantiate(projectilePrefab, transform.position, Quaternion.identity)
                    .GetComponent<Movement2D>()
                    .MoveTo(new Vector3(0.2f, 1, 0));
                break;
        }
    }
}