using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacterEntity : CharacterEntity
{
    [Header("Attacks")]
    [SerializeField] private Transform attackContainerTransform;
    [SerializeField] private GameObject basicAttackObject;

    private List<AttackHolder> playerAttackObjectsList = new List<AttackHolder>();

    private void Start()
    {
        AddAttackObject(basicAttackObject);
    }

    public void AddAttackObject(GameObject attackObject)
    {
        var instance = Instantiate(attackObject, attackContainerTransform);
        var instanceAttackHolder = instance.GetComponent<AttackHolder>();

        if(instanceAttackHolder == null)
            throw new MissingComponentException($"Missing {nameof(AttackHolder)} Component in {attackObject.name}");

        playerAttackObjectsList.Add(instanceAttackHolder);
    }
}
