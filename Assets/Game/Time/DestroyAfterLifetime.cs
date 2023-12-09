using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyAfterLifetime : MonoBehaviour
{
    [Header("Event")]
    public UnityEvent OnLifetimeEnded = new UnityEvent();

    [Header("Data")]
    [SerializeField] private float lifetime;
    [SerializeField] private bool onStart = true;

    private float timer;

    private void Start()
    {
        if (!onStart) return;

        StartTime();
    }

    private void Update()
    {
        if (timer <= 0f) return;

        timer -= GameplayTime.deltaTime;

        if (timer <= 0f)
        {
            EndTime();
        }
    }

    public void StartTime()
    {
        timer = lifetime;
    }

    public void SetTime(float value)
    {
        lifetime = value;
    }

    public void ResetTime()
    {
        timer = lifetime;
    }

    private void EndTime()
    {
        OnLifetimeEnded?.Invoke();
        Destroy(gameObject);
    }
}
