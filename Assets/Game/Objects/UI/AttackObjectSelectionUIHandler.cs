using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObjectSelectionUIHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private HeroCharacterEntity heroEntity;

    private void Start()
    {
        HideUI();
    }

    public void AddObjectToHero(AttackObjectData objectData)
    {
        heroEntity.AddAttackObject(objectData.AttackObjectPrefab);
        HideUI();
        GameplayTime.Resume();
    }

    private void HideUI()
    {
        gameObject.SetActive(false);
    }
}
