using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance = null;
    AudioSource _audioSource;

    private void Awake() //region & endregion makes collapsble
    {
        #region Singleton Pattern (Simple)
        if(Instance == null)
        {
            //doesnt exist yet - make singleton
            Instance = this;
            DontDestroyOnLoad(gameObject);
            //setup this object if needed
            _audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }
 

    //put outside of void awake to give functionality to play new music
    public void PlayMusic(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
