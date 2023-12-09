using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Attack : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent OnAttackStarted = new UnityEvent();
    public UnityEvent OnAttackEnded = new UnityEvent();

    [Header("Attack Data")]
    [SerializeField] protected int damageValue;
    [SerializeField, Layer] protected int collisionLayer;

    protected bool isActive;

    public virtual void StartAttack()
    {
        SetIsActive(true);
        OnAttackStarted?.Invoke();
    }

    public virtual void EndAttack()
    {
        SetIsActive(false);
        OnAttackEnded?.Invoke();
    }

    public void SetIsActive(bool active)
    {
        isActive = active;
    }
}
