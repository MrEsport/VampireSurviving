using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBrain : BrainEntityController
{
    [SerializeField] protected Transform targetTransform;

    public void SetTarget(Transform target)
    {
        targetTransform = target;
    }

    private void Update()
    {
        if (targetTransform == null) return;

        entity.SetDirection((targetTransform.position -  transform.position).normalized);
        entity.Move();
    }
}
