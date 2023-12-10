using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceProgressUIHandler : MonoBehaviour
{
    [SerializeField] private Slider progressSlider;

    public void UpdateProgressUIValue(float progress)
    {
        progressSlider.value = progress;
    }
}
