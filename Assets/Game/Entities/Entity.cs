using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour, Damageable
{
    [SerializeField] protected EntityData data;

    protected Vector2 direction;

    public abstract void Move();
    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void TakeDamage(int damage)
    {
        data.Health -= damage;
    }
}
