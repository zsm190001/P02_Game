using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float launchForce = 50f;
    //[SerializeField] private float destroyAfterSeconds = 5f;
    [SerializeField] public PlayerHealth pH;
    [SerializeField] private GameObject projectile;
    private float distanceBetweenTarget;
    [SerializeField]
    private Transform[]
        projectileSpawnPoint;
    private float countdownBetweenFire = 0f;
    [SerializeField] private float fireRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * launchForce;
    }

    // Update is called once per frame
    void Update()
    {
       
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
    void ShootAtPlayer()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        pH.PlayerTakeDamage(1);
        Destroy(collision.gameObject);
    }
}
