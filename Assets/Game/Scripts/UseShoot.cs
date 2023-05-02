using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UseShoot : MonoBehaviour
{
    //layer system for shootable/not
    [SerializeField] private LayerMask _layersToShoot = -1;
    [SerializeField] private float _shootDistance = 30;
    [SerializeField] private Camera _camera;

    [SerializeField] private ParticleSystem _impactParticle;
    [SerializeField] private AudioSource _shootSound;

    private int _damageAmount = 1;
	public void OnShoot(InputValue value)
	{
        if (value.isPressed)
        {
            //Debug.Log("Shoot");
            Shoot();
        }     
	}

    private void Shoot()
    {
        Vector3 rayStartPos = _camera.transform.position;
        Vector3 rayDirection = _camera.transform.forward;
        Debug.DrawRay(rayStartPos, rayDirection * _shootDistance,
            Color.cyan, 1);
        //draws debug ray, rayDirection is actually ray end point
        RaycastHit hitInfo;
        if(Physics.Raycast(rayStartPos, rayDirection, out hitInfo,
            _shootDistance, _layersToShoot))
        {
            Debug.Log("Shoot");
            if(_impactParticle != null)
            {
                Instantiate(_impactParticle, hitInfo.point, Quaternion.identity);
            }
            if(_shootSound != null){
                AudioSource newSound = Instantiate
                    (_shootSound, transform.position, Quaternion.identity);
                Destroy(newSound.gameObject, newSound.clip.length);
            }
            Shootable shootableObject = 
                hitInfo.transform.GetComponent<Shootable>();
            if(shootableObject != null)
            {
                shootableObject.Shoot(_damageAmount);
            }
        }

    }
}
