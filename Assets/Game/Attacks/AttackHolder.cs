using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHolder : MonoBehaviour
{
    [SerializeField] private Attack attack;
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
                StartAttack();
            }
        }

        if (uptimeTimer > 0f)
        {
            uptimeTimer -= GameplayTime.deltaTime;

            if(uptimeTimer <= 0f)
            {
                EndAttack();
            }
        }
    }

    public void StartAttack()
    {
        attack.StartAttack();
    }

    public void EndAttack()
    {
        attack.EndAttack();
    }

    public void SetDirection(Vector2 direction)
    {
        float angle = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
