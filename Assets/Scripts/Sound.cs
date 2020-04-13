using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    public float pitch;

    [Range( 0f,1.0f)]
    public float volumn;

    [HideInInspector]
    public AudioSource source;
}
