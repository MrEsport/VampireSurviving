using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeaterHolder : AttackHolder
{
    [Header("Repeater")]
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private float uptime = .05f;

    private float cooldownTimer = 0f;
    private float uptimeTimer = 0f;

    private void Start()
    {
        cooldownTimer = cooldown;
    }

    private void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= GameplayTime.deltaTime;

            if (cooldownTimer <= 0f)
            {
                cooldownTimer += cooldown;
                uptimeTimer = uptime;
                attack.StartAttack();
            }
        }

        if (uptimeTimer > 0f)
        {
            uptimeTimer -= GameplayTime.deltaTime;

            if (uptimeTimer <= 0f)
            {
                attack.EndAttack();
            }
        }
    }
}
