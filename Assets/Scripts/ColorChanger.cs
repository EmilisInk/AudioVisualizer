using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorChanger : MonoBehaviour
{
    [ColorUsage(true, true)]
    public Color[] colors;
    public float fadeDuration = 0.2f;

    private Renderer renderer;
    private int index = 0;
    private static int EmissionID = Shader.PropertyToID("_EmissionColor");

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        BeatDetector.Instance.OnBeat.AddListener(ChangeColor);

        renderer.material.EnableKeyword("_EMISSION");
        renderer.material.SetColor(EmissionID, colors[index]);
    }

    void ChangeColor()
    {
        index = (index + 1) % colors.Length;
        renderer.material.DOColor(colors[index], EmissionID, fadeDuration).SetEase(Ease.OutQuad);
    }
}
