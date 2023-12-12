using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUIHandler : MonoBehaviour
{
    [SerializeField] private Slider progressSlider;

    [SerializeField] private float initialValue = 0f;
    [SerializeField] private float min = 0f;
    [SerializeField] private float max = 1f;

    public float GetValue { get => progressSlider.value; }

    private void Start()
    {
        progressSlider.maxValue = max;
        progressSlider.minValue = min;
        progressSlider.value = initialValue;
    }

    public void SetValue(int value)
    {
        SetValue((float)value);
    }

    public void SetValue(float value)
    {
        progressSlider.value = value;
    }
}
