using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioHandler : MonoBehaviour
{
    [SerializeField] AudioSource audioRef;
    [SerializeField] AudioSource mainAudioHolderRef;
    [SerializeField] AudioClip deathSoundClip;
    [SerializeField] AudioClip walkingClip;

    [SerializeField] AudioClip[] swingingWeaponEffectSFX;
    [SerializeField] AudioClip[] hurtSoundClips;
    [SerializeField] AudioClip[] pickupSoundClips;
    [SerializeField] AudioClip[] impactSoundClips;
    [SerializeField] AudioClip[] eatSoundClips;
    [SerializeField] AudioClip[] drinkSoundClips;

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
        audioRef.clip = hurtSoundClips[Random.Range(0, hurtSoundClips.Length)];
        audioRef.Play();
    }

    public void PlayPickupSound()
    {
        audioRef.clip = pickupSoundClips[Random.Range(0, pickupSoundClips.Length)];
        audioRef.Play();
    }

    public void PlaySwingSound()
    {
        audioRef.clip = swingingWeaponEffectSFX[Random.Range(0, swingingWeaponEffectSFX.Length)];
        audioRef.Play();
    }

    public void PlayimpactSound()
    {
        audioRef.clip = impactSoundClips[Random.Range(0, impactSoundClips.Length)];
        audioRef.Play();
    }

    public void PlayEatSound()
    {
        audioRef.clip = eatSoundClips[Random.Range(0, eatSoundClips.Length)];
        audioRef.Play();
    }

    public void PlayDrinkSound()
    {
        audioRef.clip = drinkSoundClips[Random.Range(0, drinkSoundClips.Length)];
        audioRef.Play();
    }

    public void PlayDeathSound()
    {
        //switching to main audio handler in order to turn off the theme music
        mainAudioHolderRef.clip = deathSoundClip;
        audioRef.Play();
    }
}
