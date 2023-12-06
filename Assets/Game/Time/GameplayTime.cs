using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayTime : Time
{
    private static float timeFactor = 1f;

    public static new float deltaTime
    {
        get => Time.deltaTime * timeFactor;
    }

    public static void Pause()
    {
        timeFactor = 0f;
    }

    public static void Resume()
    {
        timeFactor = 1f;
    }
}
