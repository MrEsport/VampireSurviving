using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveHurtBoxAttack : Attack
{
    [Header("Hurtbox")]
    [SerializeField] private Collider2D hurtbox;
    [SerializeField] private bool hitOncePerActivation = true;

    private List<Damageable> alreadyHitTargets = new List<Damageable>();

    private void Start()
    {
        StartAttack();
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer != collisionLayer) return;

        var damageable = collision.GetComponent<Damageable>();
        if (damageable == null) return;
        if (hitOncePerActivation && alreadyHitTargets.Contains(damageable)) return;

        damageable.TakeDamage(damageValue);

        if (hitOncePerActivation)
            alreadyHitTargets.Add(damageable);
    }
}
