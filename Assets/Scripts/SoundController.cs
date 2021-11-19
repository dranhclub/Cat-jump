using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip hitTrapSound;
    [SerializeField] private AudioClip hitStarSound;
    [SerializeField] private AudioClip completeLVSound;
    [SerializeField] private AudioClip fallingSound;
    [SerializeField] private AudioClip hitBtnSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playJumpSfx()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void playHitTrapSfx()
    {
        audioSource.PlayOneShot(hitTrapSound);
    }

    public void playCompleteLVSfx()
    {
        audioSource.PlayOneShot(completeLVSound);
    }

    public void playHitStarSfx()
    {
        audioSource.PlayOneShot(hitStarSound);
    }

    public void playFallingSfx()
    {
        audioSource.PlayOneShot(fallingSound);
    }

    public void playHitBtnSfx()
    {
        audioSource.PlayOneShot(hitBtnSound);
    }
}
