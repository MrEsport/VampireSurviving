using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class Entity : MonoBehaviour, Damageable
{
    [SerializeField] protected EntityData data;

    [Header("Events")]
    [SerializeField] public UnityEvent<Vector2> OnCharacterDirectionSet = new UnityEvent<Vector2>();
    [SerializeField] public UnityEvent<int> OnHealthUpdate = new UnityEvent<int>();
    [SerializeField] public UnityEvent OnDeath = new UnityEvent();

    protected Vector2 direction;

    protected virtual void Start()
    {
        data.Health = data.MaxHealth;
    }

    public virtual void Move()
    {
        transform.Translate(direction * data.MoveSpeed * GameplayTime.deltaTime);
    }

    public virtual void Kill()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    public void SetDirection(Vector2 normalizedDirection)
    {
        direction = normalizedDirection;
        OnCharacterDirectionSet?.Invoke(direction);
    }

    public void TakeDamage(int damage)
    {
        data.Health = Mathf.Max(0, data.Health - damage);
        OnHealthUpdate?.Invoke(data.Health);

        if(data.Health <= 0f)
        {
            Kill();
        }
    }
}
