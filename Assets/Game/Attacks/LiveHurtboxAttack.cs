using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveHurtBoxAttack : Attack
{
    [Header("Hurtbox")]
    [SerializeField] private Collider2D hurtbox;

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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isActive) return;
        if (collision.gameObject.layer != collisionLayer) return;

        var damageable = collision.GetComponent<Damageable>();
        if (damageable == null) return;

        damageable.TakeDamage(damageValue);
    }
}
