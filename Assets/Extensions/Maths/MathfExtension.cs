using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathfExtension
{
    public static Vector2 RandomPointInCircle(Vector2 center, float radius)
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Random.Range(0f, radius) + center;
    }
}
