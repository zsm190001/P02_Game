using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageCollideAudio 
{
    public static AudioSource PlayClip2D(AudioClip clip, float volume)
    {
        //create new AudioSource
        GameObject audioObject = new GameObject("DamageCollideAudio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        //config to be 2D
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
        //destroy when done - destroy object not source, so can play again
        Object.Destroy(audioObject, clip.length);
        //return it
        return audioSource;
    }
}
