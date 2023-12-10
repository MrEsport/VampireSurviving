using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackObjectUIButtonHandler : MonoBehaviour
{
    [Header("Attack Object")]
    [SerializeField] private AttackObjectData data;

    [Header("Dependencies")]
    [SerializeField] private AttackObjectSelectionUIHandler attackSelectionUIHandler;
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text labelText;
    [SerializeField] private Image iconImage;

    private void Start()
    {
        button.onClick.AddListener(AddObjectToHero);

        InitUIData();
    }

    private void InitUIData()
    {
        labelText.text = data.Label;
        iconImage.sprite = data.Icon;
    }

    private void AddObjectToHero()
    {
        attackSelectionUIHandler.AddObjectToHero(data);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(AddObjectToHero);
    }
}
