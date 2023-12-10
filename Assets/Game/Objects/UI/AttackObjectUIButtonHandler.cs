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
        InitUIData();

        button.onClick.AddListener(() => attackSelectionUIHandler.AddObjectToHero(data));
    }

    private void InitUIData()
    {
        labelText.text = data.Label;
        iconImage.sprite = data.Icon;
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(() => attackSelectionUIHandler.AddObjectToHero(data));
    }
}
