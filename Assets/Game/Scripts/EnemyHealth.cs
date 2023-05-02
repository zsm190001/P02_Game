using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public int _currentHealth;
    [SerializeField] private int _currentEnemyHealth = 3;

    //[SerializeField] private int _objectCounter

    [SerializeField] public Shootable _shootable;
    public bool isEnemy;
    KillCounter killCounterScript;

    public Slider slider;
    public HealthBar healthbar;

    private void Start()
    {
        _currentHealth = _currentEnemyHealth;
        healthbar.SetMaxHealth(_currentEnemyHealth);
    
        isEnemy = true;
        killCounterScript = GameObject.Find("KillCounter").GetComponent<KillCounter>();
    }
     
    public void Update()
    {
        
    }

    private void OnEnable()
    {
        //watch shot event
        if (_shootable != null)
        {
            _shootable.Shot.AddListener(TakeDamage);
        }
    }

    private void OnDisable()
    {
        //stop watching shot event
        _shootable.Shot.RemoveListener(TakeDamage);
    }

    public void TakeDamage(int damageAmount)
    {
        //check health, determing die or not
        _currentHealth -= damageAmount;
        healthbar.SetHealth(_currentHealth);

        //current health above 0
        if (_currentHealth > 0)
        {   
            Debug.Log("Enemy Health Remaining: " + _currentEnemyHealth);   
        }
        //current health 0 or lower
        else if (_currentHealth <= 0)
        {
            die();
            killCounterScript.AddKill();
            Debug.Log("Enemy Died");
        }
    }

    public void die()
    {
       //deletes obj
        gameObject.SetActive(false);
        killCounterScript.AddKill();
            //int highscore = PlayerPrefs.GetInt("highscore");
            //highscore += 1;
        Debug.Log("enemy died:");
        
    }
}
