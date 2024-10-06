using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioSettings scriptableObject;
    [SerializeField] private AudioClip roomSong1;
    [SerializeField] private AudioClip roomSong2;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider masterSlider;    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
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
    public void ChangeSong()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();  
        }
        if (_audioSource.clip == roomSong1)
        {
            _audioSource.clip = roomSong2;
            _audioSource.Play();
        }
        else 
        {
            _audioSource.clip = roomSong1;
            _audioSource.Play();
        }
    }
}
