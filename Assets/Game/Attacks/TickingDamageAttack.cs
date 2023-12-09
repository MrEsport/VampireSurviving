using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickingDamageAttack : Attack
{
    [Header("Ticks Data")]
    [SerializeField] private float tickIntervalDuration;

    private float tickTimer;
    private List<Damageable> damageablesInArea = new List<Damageable>();

    void Start()
    {
        StartAttack();
    }

    void Update()
    {
        if (!isActive) return;

        tickTimer -= GameplayTime.deltaTime;

        if (tickTimer <= 0f)
        {
            ApplyTickDamage();
            tickTimer += tickIntervalDuration;
        }
    }

    public override void StartAttack()
    {
        base.StartAttack();
        tickTimer = tickIntervalDuration;
    }

    public override void EndAttack()
    {
        base.EndAttack();
        tickTimer = -1f;
        damageablesInArea.Clear();
    }

    private void ApplyTickDamage()
    {
        if (damageablesInArea.Count <= 0) return;

        foreach (var damageable in damageablesInArea)
            damageable.TakeDamage(damageValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive) return;
        if (collision.gameObject.layer != collisionLayer) return;

        var damageable = collision.GetComponent<Damageable>();
        if (damageable == null) return;

        damageablesInArea.Add(damageable);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isActive) return;
        if (collision.gameObject.layer != collisionLayer) return;

        var damageable = collision.GetComponent<Damageable>();
        if (damageable == null) return;
        if (!damageablesInArea.Contains(damageable)) return;

        damageablesInArea.Remove(damageable);
    }
}
