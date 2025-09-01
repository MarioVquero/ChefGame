using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour
{
    public int lives = 2;
    public int score;
    public float gameTimer = 60f;

    public TMP_Text scoreText;
    public TMP_Text TimerText;

    public Image livesIMG;

    public Sprite[] spriteLives;




    // Start is called before the first frame update
    void Start()
    {
        UpdateLivesDisplay(lives);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;

            float seconds = Mathf.FloorToInt(gameTimer % 60);

            TimerText.text = string.Format("{0:00}", seconds);

            scoreText.text = "Score: " + score.ToString();

        }
        else
        {
            Debug.Log("GAMEOVER");
            SceneManager.LoadScene(2);
        }


    }

    public void UpdateLivesDisplay(int currentLives)
    {
        livesIMG.sprite = spriteLives[currentLives];
    }
    

}
