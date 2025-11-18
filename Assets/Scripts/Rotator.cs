using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotation = new Vector3(.3f, 1, .1f);
    public float baseSpeed = 60;
    public float loudnessMultiplier = 200;

    private void Update()
    {
        var speed = BeatDetector.Loudness * loudnessMultiplier * baseSpeed * Time.deltaTime;

        transform.Rotate(rotation * speed);
    }
}
