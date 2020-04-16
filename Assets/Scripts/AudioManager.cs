using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    private Sound current;
    public String[,] sound_names = new string[3, 3] { { "THPH", "THPN", "THPL" }, { "TNPH","TNPN","TNPL" }, {"TLPH","TLPN","TLPL" } };

    public int tempo_indice = 1;
    public int pitch_indice = 1;
    public string song_name;

    PlayPause playpauseAni;

    AudioChorusFilter audioChrousFilter;
    public float depth;
    public float rate;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volumn;
            s.source.pitch = s.pitch;
        }
        current = Array.Find(sounds, sound => sound.name == "TNPN");
        playpauseAni = gameObject.GetComponent<PlayPause>();
        audioChrousFilter = gameObject.GetComponent<AudioChorusFilter>();
    }

    // Update is called once per frame
    public void Play ()
    {
        current.source.Play();
    }

    public void Pause()
    {
        current.source.Pause();
    }

    public void Select(string name)
    {
        current = Array.Find(sounds, sound => sound.name == name);
    }

    public void decreaseTempo()
    {
        tempo_indice += 1;
        if(tempo_indice > 2)
        {
            tempo_indice = 2;
        }
        updateSound();
    }

    public void increaseTempo()
    {
        tempo_indice -= 1;
        if(tempo_indice < 0)
        {
            tempo_indice = 0;
        }
        updateSound();
    }

    public void decreasePitch()
    {
        pitch_indice += 1;
        if(pitch_indice > 2)
        {
            pitch_indice = 2;
        }
        updateSound();
    }

    public void increasePitch()
    {
        pitch_indice -= 1;
        if(pitch_indice < 0)
        {
            pitch_indice = 0;
        }
        updateSound();
    }

    public void updateSound()
    {
        current.source.Pause();
        //playpauseAni.playing = false;
        var updated_sound_name = sound_names[tempo_indice, pitch_indice];
        current = Array.Find(sounds, sound => sound.name == updated_sound_name);
    }

    public void updateChrousFilter(float rate, float depth)
    {
        audioChrousFilter.depth = depth;
        audioChrousFilter.rate = rate;
    }
}
