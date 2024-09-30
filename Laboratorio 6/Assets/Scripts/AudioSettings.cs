using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Audio Settings")]
public class AudioSettings : ScriptableObject
{
    public float masterVolume = 1f;
    public float musicVolume = 1f;
    public float sfxVolume = 0.5f;
}
