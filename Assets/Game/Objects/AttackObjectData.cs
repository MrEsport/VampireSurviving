using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Attack/Object Data")]
public class AttackObjectData : ScriptableObject
{
    public string Label;
    public Sprite Icon;
    public GameObject AttackObjectPrefab;

    private void OnEnable()
    {
        Label = "New Object";
    }
}
