using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class BeatDetector : MonoBehaviour
{
    public static BeatDetector Instance { get; private set; }
    public static float Loudness {  get; private set; }

    [Header("Analaysis Settings")]
    public int sampleRate = 1024;
    public float beatTreshold = 1.35f;
    public int historyLength = 43;

    [Header("Events")]
    public UnityEvent OnBeat;

    private AudioSource source;
    private float[] samples;
    private float[] history;
    int historyPos;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
        samples = new float[sampleRate];
        history = new float[historyLength];
        historyPos = 0;
    }

    private void Update()
    {
        if (!source.isPlaying) return;

        //pull audio samples
        source.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);

        //compute energy
        float energy = 0;
        for (int i = 0; i < sampleRate; i++)
        {
            energy += samples[i] * samples[i];
        }
        Loudness = energy;


        float avgEnergy = 0;
        for(int i = 0;i < historyLength; i++)
        {
            avgEnergy += history[i];
        }
        
        avgEnergy /= historyLength;

        //detect a beat
        if (energy > beatTreshold * avgEnergy)
        {
            OnBeat.Invoke();
        }

        //push history
        history[historyPos++] = energy;
        historyPos = (historyPos + 1) % historyLength;

    }
}
