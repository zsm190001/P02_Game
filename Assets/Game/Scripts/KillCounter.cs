using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class KillCounter : MonoBehaviour
{
    //public TextMeshProUGUI counterText;
   
    int kills;
    [SerializeField] private TextMeshProUGUI _currentKillTextview;
    public static int _currentKill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowKills();
        updateHighScore();
    }


    private void ShowKills()
    {
        _currentKillTextview.text = kills.ToString();
    }

    public void AddKill()
    {
        kills++;
    }
    public void updateHighScore()
    {
        //compare score to highscore
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (_currentKill > highScore)
        {
            //save current score as new high score
            PlayerPrefs.SetInt("HighScore", _currentKill);
            Debug.Log("New high score: " + _currentKill);
        }
    }
}
