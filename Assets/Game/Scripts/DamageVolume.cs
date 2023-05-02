using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class DamageVolume : MonoBehaviour
{
    [SerializeField] AudioClip _DamageCollideAudio = null;
    [SerializeField] ParticleSystem DamageParticles;
    public PlayerHealth pH;

    //public GameObject youLoseText;
    private void OnTriggerEnter(Collider other) //char controllers only receive OnTrigger events 
                                                    //not OnCollission events
    {
        CharacterController characterController = other.gameObject.GetComponent<CharacterController>();

        if(characterController != null)
        {
            pH.PlayerTakeDamage(1);         //connect to health - damage volume
            Instantiate(DamageParticles, transform.position, transform.rotation);
            DamageCollideAudio.PlayClip2D(_DamageCollideAudio, 1);
            
        }
        
        //} 
        //PROJ 1 EX
        //detect if its the player
        //PlayerShip playerShip
        //    = other.gameObject.GetComponent<PlayerShip>();

        ////if we found something valid continue
        //if (playerShip != null)
        //{
        //    //do something
        //    playerShip.Kill();
        //    youLoseText.SetActive(true);
        //    Instantiate(_DamageParticles, transform.position, transform.rotation);
        //    DamageCollideAudio.PlayClip2D(_DamageCollideAudio, 1);
        //}

    }
}
