using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayControler : MonoBehaviour
{
    public static GamePlayControler instance;

    [SerializeField] private Text scoreText;
    private int score;

    [SerializeField] private Text scoreTextFinal;
    [SerializeField] private Text highScoreTextFinal;
    public bool isPlayerAlive;

    [SerializeField] private GameObject GOpanel;

  
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        isPlayerAlive = true;
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "x"+score;
    }

    public void RestartGame()
    {
       
        ShowEndRes();
        GOpanel.SetActive(true);
        isPlayerAlive = false;
        Invoke(nameof(ReloadGame),4f);
    }
     void ReloadGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

     void ShowEndRes()
     {
         if (PlayerPrefs.HasKey("hightScore"))
         {
             if (score > PlayerPrefs.GetInt("hightScore"))
             {
                 PlayerPrefs.SetInt("hightScore",score);
                 highScoreTextFinal.text = score.ToString();
             } 
             else
             {
                 highScoreTextFinal.text = PlayerPrefs.GetInt("hightScore").ToString();
             }
         }
         else
         {
             PlayerPrefs.SetInt("hightScore",score);
             highScoreTextFinal.text = score.ToString();
         }

         scoreTextFinal.text = score.ToString();

     }
}
