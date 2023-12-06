using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected EntityData data;

    protected Vector2 direction;

    public abstract void Move();
    public abstract void Attack();
    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
