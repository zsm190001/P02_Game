using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class Level01Controller : MonoBehaviour
{
   // public Health eH;
    public KillCounter hS; //highscore 
   

    private void Start()
    {
        
    }
    private void Awake()
    {
        //dont allow the mouse to move around game window
        Cursor.lockState = CursorLockMode.Locked;
        //mouse invisible
        Cursor.visible = false;
    }
       void Update()
    {

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            ExitLevel();                 
        }
    }

  
 
    
    public void ExitLevel()
    {
        SceneManager.LoadScene("MainMenu");
        hS.updateHighScore();
    }

}
