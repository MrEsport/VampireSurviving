using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        OnDeath.AddListener(() => EditorApplication.isPlaying = false);
    }

    public void AddAttackObject(GameObject attackObject)
    {
        var instance = Instantiate(attackObject, attackContainerTransform);
        var instanceAttackHolder = instance.GetComponent<AttackHolder>();

        if(instanceAttackHolder == null)
            throw new MissingComponentException($"Missing {nameof(AttackHolder)} Component in {attackObject.name}");

        playerAttackObjectsList.Add(instanceAttackHolder);
        OnCharacterDirectionSet.AddListener(instanceAttackHolder.OnCharacterDirectionSet);
    }

    private void OnDisable()
    {
        while (playerAttackObjectsList.Count > 0)
        {
            OnCharacterDirectionSet.RemoveListener(playerAttackObjectsList[0].OnCharacterDirectionSet);
            playerAttackObjectsList.RemoveAt(0);
        }
        OnDeath.RemoveListener(() => EditorApplication.isPlaying = false);
    }
}
