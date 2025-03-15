using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBase : MonoBehaviour
{
    public AudioClip[] clip;
    public AudioSource[] audioSources;
    private int index;
    
    

    public void PlayRandomClip()
    {
        if (index >= audioSources.Length) index = 0;
        audioSources[index].clip = clip[Random.Range(0, clip.Length)];
        audioSources[index].Play(); 
        index++;
    }




}
