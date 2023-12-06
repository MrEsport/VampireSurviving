using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEntity : Entity
{
    public override void Move()
    {
        transform.Translate(direction * data.MoveSpeed * GameplayTime.deltaTime);
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
