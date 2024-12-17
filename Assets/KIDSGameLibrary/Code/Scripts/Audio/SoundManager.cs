using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundEffectType { SFX, BGM }

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] SoundEffectsProfile mainProfile;
    [SerializeField] SoundEffectsProfile[] subProfiles;

    // Flags to control audio playback.
    [SerializeField] bool SFXOn = true, BGMOn = true; 

    Dictionary<string, SoundEffect> effects = new Dictionary<string, SoundEffect>();

    [SerializeField] AudioSource audioSource;

    void Start()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();

        foreach(SoundEffect sfx in mainProfile.effects) { effects.Add(sfx.effectID, sfx); }
        foreach (SoundEffectsProfile profile in subProfiles)
        {
            foreach (SoundEffect sfx in profile.effects) { effects.Add(sfx.effectID, sfx); }
        }
        
        PlaySFX("Start");
    }

    public void PlaySFX(string soundID)
    {
        if (!effects.ContainsKey(soundID))
        {
            Debug.LogWarning("No sound ID '" + soundID + "' found.");
            return;
        }

        SoundEffect fx = effects[soundID];

        switch (fx.effectType)
        {
            case SoundEffectType.SFX: if (!SFXOn) { return; } break;
            case SoundEffectType.BGM: if (!BGMOn) { return; } break;
        }

        audioSource.PlayOneShot(fx.effectClip[UnityEngine.Random.Range(0, fx.effectClip.Length)], fx.soundVolume);
    }
}

[Serializable]
public class SoundEffect
{
    public string effectID;             // The string by which we'll identify the sound.

    [Range(0, 1)]
    public float soundVolume = 1f;      // The volume at which we'll play the sound effect.

    public AudioClip[] effectClip;        // The sound effect audio file.
    public SoundEffectType effectType;  // The SFX type.
}