using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class NPCBehavior : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject projectile;
    private float distanceBetweenTarget;
    [SerializeField] private Transform[]
        projectileSpawnPoint;
    [SerializeField] public PlayerHealth pH;

    private float countdownBetweenFire = 0f;
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private float launchForce = 50f;
    [SerializeField] private Rigidbody rb;

  
    //[SerializeField] private float destroyAfterSeconds = 5f;

    //[SerializeField] public EnemyProjectile eP;
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) < 25)
        {
            //looks & moves to target within certain distance
            transform.position = Vector3.MoveTowards(transform.position,
                        (target.position), speed * Time.deltaTime);
            transform.LookAt(target);
            Debug.Log("You're Seen!");
            if (countdownBetweenFire <= 0f)
            {
                //spawn projectiles if in certain distance
                foreach (Transform SpawnPoints in projectileSpawnPoint)
                {
                    Instantiate(projectile, SpawnPoints.position, transform.rotation);
                    Debug.Log("Projectile Spawned");
                    rb.velocity = transform.forward * launchForce;
                    //OnCollisionEnter();
                }

                countdownBetweenFire = 1f / fireRate;
                //if firerate is 2 = shooting 2 projectiles in 1 sec = countdown starts from 0.5f
            }
            countdownBetweenFire -= Time.deltaTime;
            //every sec, countdownbtwfire is reduced by 1
        }
        
       }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            pH.PlayerTakeDamage(1);
            Destroy(collision.gameObject);
        }
    }
            
}
