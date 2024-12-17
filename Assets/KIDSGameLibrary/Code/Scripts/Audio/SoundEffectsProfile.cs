using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound Profile", menuName = "Sound Profile")]
public class SoundEffectsProfile : ScriptableObject
{
    public SoundEffect[] effects;
}