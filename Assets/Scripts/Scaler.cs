using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    public float popScale = 1.3f;
    public float duration = 0.15f;

    Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
        BeatDetector.Instance.OnBeat.AddListener(OnBeat);
    }

    void OnBeat()
    {
        //turn off previous animations
        transform.DOKill();

        //pop animation
        transform.DOScale(originalScale, duration).ChangeStartValue(originalScale * popScale).SetEase(Ease.InQuad);

    }
}
