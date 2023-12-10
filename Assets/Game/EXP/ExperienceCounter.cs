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
    [SerializeField] private UnityEvent OnGoalReached = new UnityEvent();

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
        SetCount(count + gain);

        if(count >= goal)
            GoalReached();
    }

    private void SetCount(int value)
    {
        count = Mathf.Min(value, goal);
        OnCounterProgressUpdate?.Invoke(count / (float)goal);
    }

    private void GoalReached()
    {
        ResetCount();
        GameplayTime.Pause();
        OnGoalReached?.Invoke();
    }
}
