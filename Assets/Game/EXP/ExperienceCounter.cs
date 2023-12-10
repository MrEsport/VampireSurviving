using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExperienceCounter : MonoBehaviour
{
    [SerializeField] private int goal;
    [SerializeField, ProgressBar("EXP Count", nameof(goal), EColor.Blue)] private int count;

    [Header("Event")]
    [SerializeField] private UnityEvent<float> OnCounterProgressUpdate = new UnityEvent<float>();

    private void Start()
    {
        ResetCount();
    }

    public void ResetCount()
    {
        SetCount(0);
    }

    public void GainExp(int gain)
    {
        SetCount(Mathf.Min(count + gain, goal));
    }

    private void SetCount(int value)
    {
        count = value;
        OnCounterProgressUpdate?.Invoke(count / (float)goal);
    }
}
