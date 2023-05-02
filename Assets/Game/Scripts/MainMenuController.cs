using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private TextMeshProUGUI _highScoreTextView;

    private void Start()
    {
        //!= null means "is not equal to nothing"
        //!=(is not equal) to null(nothing)
        if (_menuMusic != null)
        {
            AudioManager.Instance.PlayMusic(_menuMusic);
        }
        //load high score display
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();
    }
    private void Awake()
    {
        //allow the cursor to move around game window
        Cursor.lockState = CursorLockMode.Confined;
        //make the mouse cursor visible
        Cursor.visible = true;
    }


    private void ResetData()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        PlayerPrefs.DeleteKey("HighScore");
        _highScoreTextView.text = highScore.ToString();       
        
    }

    
    public void QuitGame()
    {
        Application.Quit();
    }
}
