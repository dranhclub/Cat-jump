using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip hitTrapSound;
    [SerializeField] private AudioClip hitStarSound;
    [SerializeField] private AudioClip completeLVSound;
    [SerializeField] private AudioClip fallingSound;
    [SerializeField] private AudioClip hitBtnSound;

    private AudioSource bgMusicAudioSource;
    private AudioSource soundAudioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        bgMusicAudioSource = GameObject.Find("Music").GetComponent<AudioSource>();
        DontDestroyOnLoad(bgMusicAudioSource.gameObject);
    }

    private void Start()
    {
        soundAudioSource = GetComponent<AudioSource>();
        if (Static.musicOn)
        {
            SetMusicVolume(0.3f);
        }
        else
        {
            SetMusicVolume(0.0f);
        }
        bgMusicAudioSource.Play();
    }

    public void SetMusicVolume(float volume)
    {
        bgMusicAudioSource.volume = volume;
    }

    public void playJumpSfx()
    {
        if (Static.soundOn)
        {
            soundAudioSource.PlayOneShot(jumpSound);
        }
    }

    public void playHitTrapSfx()
    {
        if (Static.soundOn)
        {
            soundAudioSource.PlayOneShot(hitTrapSound);
        }
    }

    public void playCompleteLVSfx()
    {
        if (Static.soundOn)
        {
            soundAudioSource.PlayOneShot(completeLVSound);
        }
    }

    public void playHitStarSfx()
    {
        if (Static.soundOn)
        {
            soundAudioSource.PlayOneShot(hitStarSound);
        }
    }

    public void playFallingSfx()
    {
        if (Static.soundOn)
        {
            soundAudioSource.PlayOneShot(fallingSound);
        }
    }

    public void playHitBtnSfx()
    {
        if(Static.soundOn)
        {
            soundAudioSource.PlayOneShot(hitBtnSound);
        }
    }
}
