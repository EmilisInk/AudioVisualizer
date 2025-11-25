using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float distance = 300;
    public float smoothTime = 1;

    private Vector3 startPos;
    private Vector3 direction;

    private void Start()
    {
        startPos = transform.position;
        if (transform.parent != null)
        {
            direction = startPos - transform.parent.position;
            direction.Normalize();
        }
    }

    private void Update()
    {
        var target = startPos + direction * distance * BeatDetector.Loudness;
        transform.localPosition = Vector3.Lerp(startPos, target, smoothTime);
    }

}
