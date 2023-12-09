using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Entity : MonoBehaviour, Damageable
{
    [SerializeField] protected EntityData data;

    [Header("Events")]
    [SerializeField] public UnityEvent<Vector2> OnCharacterDirectionSet = new UnityEvent<Vector2>();

    protected Vector2 direction;

    public abstract void Move();
    public void SetDirection(Vector2 normalizedDirection)
    {
        direction = normalizedDirection;
        OnCharacterDirectionSet.Invoke(direction);
    }

    public void TakeDamage(int damage)
    {
        data.Health -= damage;
    }
}
