using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int _currentHealth;
    public int maxHealth = 5;
    //[SerializeField] private int _currentPlayerHealth = 5;


    //[SerializeField] private int _objectCounter

    [SerializeField] public Shootable _shootable;
    public bool isPlayer;

    public Slider slider;
    public HealthBar healthbar;

    private void Start()
    {
        isPlayer = true;
        // _currentHealth = 5;
       _currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            PlayerTakeDamage(1);
        }
    }

    private void OnEnable()
    {
        //watch shot event
        if (_shootable != null)
        {
            _shootable.Shot.AddListener(PlayerTakeDamage);
        }
    }

    private void OnDisable()
    {
        //stop watching shot event
        _shootable.Shot.RemoveListener(PlayerTakeDamage);
    }

    public void PlayerTakeDamage(int damageAmount)
    {
        //check health, determing die or not
        _currentHealth -= damageAmount;
        healthbar.SetHealth(_currentHealth);
        //current health above 0
        if (_currentHealth > 0)
        {
            Debug.Log("Player Health Remaining: " + _currentHealth);

        }
        //current health 0 or lower
        else if (_currentHealth <= 0)
        {
            PlayerDie();
            Debug.Log("You Died :(");  
        }
    }

    public void PlayerDie()
    {
        //deletes obj
        gameObject.SetActive(false);
            //int highscore = PlayerPrefs.GetInt("highscore");
            //highscore += 1;
        Debug.Log("You died:");        
    }
}
