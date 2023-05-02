using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shootable : MonoBehaviour
{
    [SerializeField] private LayerMask _layersToShoot = -1;

    [SerializeField] private ParticleSystem _shootableImpactParticle;
    [SerializeField] private AudioSource _shootableHitSound;
    [SerializeField] private float _shootDistance = 30;

    [SerializeField] public int _Score;
   private Camera _camera;


    public UnityEvent<int> Shot;
    //<int> defines what type of paramekter you want to pass thru

    public void Shoot(int damageamount)
    {
        Shot?.Invoke(damageamount);
        //Debug.Log("Shot");
        if (_shootableHitSound != null)
        {
            AudioSource newSound = Instantiate
                (_shootableHitSound, transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
        }

        Vector3 rayStartPos = _camera.transform.position;
        Vector3 rayDirection = _camera.transform.forward;
        Debug.DrawRay(rayStartPos, rayDirection * _shootDistance,
            Color.cyan, 1);
        //draws debug ray, rayDirection is actually ray end point
        RaycastHit hitInfo;
        if (Physics.Raycast(rayStartPos, rayDirection, out hitInfo,
            _shootDistance, _layersToShoot))
        {
            //Debug.Log("Shoot");
            if (_shootableImpactParticle != null)
            {
                Instantiate(_shootableImpactParticle, hitInfo.point, Quaternion.identity);
            }
            if (_shootableHitSound != null)
            {
                AudioSource newSound = Instantiate
                    (_shootableHitSound, transform.position, Quaternion.identity);
                Destroy(newSound.gameObject, newSound.clip.length);
            }
            
        }
    }


}
