using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransf : MonoBehaviour
{
    public AudioMixerSnapshot snapshot;
    public float transitionTime = .1f;
    public void MakeTransition()
    {
        snapshot.TransitionTo(transitionTime);
    }
}
