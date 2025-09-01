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
    public float score;
    public float gameTimer = 60f;

    public TMP_Text scoreText;
    public TMP_Text TimerText;

    public Image livesIMG;
    public GameObject endgroup;

    public Sprite[] spriteLives;




    // Start is called before the first frame update
    void Start()
    {
        UpdateLivesDisplay(lives);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTimer > 0 && lives > -1)
        {
            gameTimer -= Time.deltaTime;

            float seconds = Mathf.FloorToInt(gameTimer % 60);

            TimerText.text = string.Format("{0:00}", seconds);

            scoreText.text = "Score: " + score.ToString();

        }
        else
        {
            Debug.Log("GAMEOVER");
            endgroup.SetActive(true);
        }


    }

    public void UpdateLivesDisplay(int currentLives)
    {
        Debug.Log(currentLives);
        livesIMG.sprite = spriteLives[currentLives];
    }

    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }
    

}
