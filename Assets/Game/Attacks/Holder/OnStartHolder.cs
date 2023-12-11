using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartHolder : AttackHolder
{
    private void Start()
    {
        attack.StartAttack();
    }
}
