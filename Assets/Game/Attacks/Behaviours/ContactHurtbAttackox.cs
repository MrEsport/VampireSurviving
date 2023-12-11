using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactHurtbAttackox : Attack
{
    [Header("Hurtbox")]
    [SerializeField] private Collider2D hurtbox;
    [SerializeField] private bool hitOncePerActivation = true;
    [SerializeField] private bool resetOnCollision;
    [SerializeField, ShowIf(nameof(resetOnCollision))] private float resetCooldown;

    private List<Damageable> alreadyHitTargets = new List<Damageable>();
    private float resetTimer;

    private void Update()
    {
        if (!resetOnCollision) return;
        if (resetTimer <= 0f) return;

        resetTimer -= GameplayTime.deltaTime;

        if (resetTimer <= 0f)
        {
            ResetAttack();
        }
    }

    public override void StartAttack()
    {
        base.StartAttack();
        hurtbox.enabled = true;
    }

    public override void EndAttack()
    {
        base.EndAttack();
        hurtbox.enabled = false;

        if (hitOncePerActivation)
            alreadyHitTargets.Clear();
    }

    private void TriggerResetTimer()
    {
        resetTimer = resetCooldown;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != collisionLayer) return;

        var damageable = collision.GetComponent<Damageable>();
        if (damageable == null) return;
        if (hitOncePerActivation && alreadyHitTargets.Contains(damageable)) return;

        damageable.TakeDamage(damageValue);

        if (hitOncePerActivation)
            alreadyHitTargets.Add(damageable);

        if(resetOnCollision)
            TriggerResetTimer();
    }
}
