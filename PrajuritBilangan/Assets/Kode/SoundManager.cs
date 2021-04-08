using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource soundFX;
    public AudioSource soundFX2;
    public AudioSource soundFX3;
    public AudioSource soundFX4;
    public AudioClip clipBG;
    public AudioClip gameOver;
    public AudioClip winClip;
    void Awake()
    {
        instance = this; 
    }


    private void Start()
    {
        if (!soundFX2.playOnAwake)
        {
            soundFX2.clip = clipBG;
            soundFX2.Play();
            soundFX2.loop = true;
        }

    }
    void Update()
    {
       
    }

    public void Stop()
    {
        soundFX2.Stop();
    }
    public void WinMusic()
    {
        soundFX2.clip = winClip;
        soundFX2.Play();
        soundFX2.loop = true;
    }
    public void GameOverMusic()
    {
        soundFX2.clip = gameOver;
        soundFX2.Play();
        soundFX2.loop = false;
    }

    public void PlaySfx(AudioClip clip)
    {
        soundFX.clip = clip;
        soundFX.volume = Random.Range(0.1f, 0.5f);
        soundFX.pitch = Random.Range(0.8f, 1f);
        soundFX.Play();
    }
    public void PlayGanti(AudioClip clip)
    {
        soundFX3.clip = clip;
        soundFX3.volume = 1f;
        soundFX3.Play();
    }

    public void PlayKena(AudioClip clip)
    {
        soundFX4.clip = clip;
        soundFX4.volume = 0.2f;
        soundFX4.Play();
    }
}
