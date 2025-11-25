using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int count = 5;
    public float radius = 5;

    private void Start()
    {
        var angle = 360f / count;
        for(float i = 0; i < 360; i+=angle)
        {
            var x = radius * MathF.Cos(i * Mathf.Deg2Rad);
            var y = radius * MathF.Sin(i * Mathf.Deg2Rad);
            Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity, transform);
        }
    }
}
