using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioHandler : MonoBehaviour
{
    [SerializeField] AudioSource audioRef;
    [SerializeField] AudioSource mainAudioHolderRef;
    [SerializeField] AudioClip hurtSoundClip;
    [SerializeField] AudioClip swingSoundClip;
    [SerializeField] AudioClip deathSoundClip;
    [SerializeField] AudioClip walkingClip;

    public void StopAudio()
    {
        audioRef.Stop();
    }
    public void LoopAudio()
    {
        audioRef.loop = true;
    }
    public void StopLoopingAudio()
    {
        audioRef.loop = false;
    }

    public void PlayWalkSound()
    {
        audioRef.clip = walkingClip;
        audioRef.Play();
    }

    public void PlayHurtSound()
    {
        audioRef.clip = hurtSoundClip;
        audioRef.Play();
    }

    public void PlaySwingSound()
    {
        audioRef.clip = swingSoundClip;
        audioRef.Play();
    }

    public void PlayDeathSound()
    {
        //switching to main audio handler in order to turn off the theme music
        mainAudioHolderRef.clip = deathSoundClip;
        audioRef.Play();
    }
}
