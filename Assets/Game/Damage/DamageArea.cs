using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField] private int damageValue;
    [SerializeField] private float damageTickInterval;

    private float timer = 0f;
    private List<Damageable> damageablesInArea = new List<Damageable>();

    void Start()
    {
        timer = damageTickInterval;
    }

    void Update()
    {
        timer -= GameplayTime.deltaTime;

        if (timer <= 0f)
        {
            ApplyDamage();
            timer = damageTickInterval;
        }
    }

    private void ApplyDamage()
    {
        if (damageablesInArea.Count <= 0) return;

        foreach (var damageable in damageablesInArea)
            damageable.TakeDamage(damageValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var damageable = collision.GetComponent<Damageable>();
        if (damageable == null) return;

        damageablesInArea.Add(damageable);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var damageable = collision.GetComponent<Damageable>();
        if (damageable == null) return;
        if (!damageablesInArea.Contains(damageable)) return;

        damageablesInArea.Remove(damageable);
    }
}
