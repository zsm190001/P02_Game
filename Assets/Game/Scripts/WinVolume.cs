using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinVolume : MonoBehaviour
{
    [SerializeField] AudioClip _WinAudio = null;
    [SerializeField] ParticleSystem _WinParticles;
    public GameObject youWinText;
    [SerializeField] private CharacterController cC;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //detect if its the player
        //CharacterController cH
            //= other.gameObject.GetComponent<CharacterController>();
        //if we found something valid continue
        if (other.gameObject.tag == "Player")
        {
            //do something
            //?????       
            
            youWinText.SetActive(true);
            //player.CancelInvoke();
            //call particles
            Instantiate(_WinParticles, transform.position, transform.rotation);
            WinAudio.PlayClip2D(_WinAudio, 1);
        }

    }
}
