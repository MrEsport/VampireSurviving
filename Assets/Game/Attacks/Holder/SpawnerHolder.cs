using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHolder : AttackHolder
{
    [Header("Spawning Data")]
    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private int amount;
    [SerializeField] private int radius;
    [SerializeField] private float cooldown = 1f;

    private float cooldownTimer = 0f;

    private void Start()
    {
        cooldownTimer = 1f;
    }

    private void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= GameplayTime.deltaTime;

            if (cooldownTimer <= 0f)
            {
                cooldownTimer += cooldown;
                SpawnAttack();
            }
        }
    }

    private void SpawnAttack()
    {
        for (int i = 0; i < amount; ++i)
        {
            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            Vector2 spawnPosition = (Vector2)transform.position + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Random.Range(0f, radius);
            
            Instantiate(attackPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
