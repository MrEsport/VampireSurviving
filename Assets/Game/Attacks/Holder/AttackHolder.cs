using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHolder : MonoBehaviour
{
    [SerializeField] protected Attack attack;
    [SerializeField] protected bool aimTowardsDirection;

    public virtual void OnCharacterDirectionSet(Vector2 direction)
    {
        if (!aimTowardsDirection) return;

        SetDirection(direction);
    }

    protected void SetDirection(Vector2 direction)
    {
        float angle = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
