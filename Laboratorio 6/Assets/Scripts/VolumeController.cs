using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioSettings scriptableObject;
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider masterSlider;
    void Awake()
    {
        masterSlider.value = scriptableObject.masterVolume;
        musicSlider.value = scriptableObject.musicVolume;
        sfxSlider.value = scriptableObject.sfxVolume;
        SetMusicVolume(scriptableObject.musicVolume);
        SetSFXVolume(scriptableObject.sfxVolume);
        SetMasterVolume(scriptableObject.masterVolume);
    }   
    public void SetMusicVolume(float volume)
    {
        scriptableObject.musicVolume = volume;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20f);
    }
    public void SetSFXVolume(float volume)
    {
        scriptableObject.sfxVolume = volume;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20f);
    }
    public void SetMasterVolume(float volume)
    {
        scriptableObject.masterVolume = volume;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20f);
    }

}
