using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackObjectSelectionUIHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private HeroCharacterEntity heroEntity;

    public void AddObjectToHero(AttackObjectData objectData)
    {
        heroEntity.AddAttackObject(objectData.AttackObjectPrefab);
    }
}
