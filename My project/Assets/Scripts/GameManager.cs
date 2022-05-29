using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public bool scored;
    public int lives = 8;

    private void Awake()
    {
        instance = this;

    }

    public int score = 0;
    public bool gameOver = false;
    GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {

        gameOverUI = GameObject.Find("Canvas-Game/GameOverPanel/GameOver");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {          
            GameOver();
            print("Game is Over");
            gameOverUI.SetActive(true);          
        }
    }

    public void lifeDecrease()
    {
        if (lives > 0)
        {
            lives--;
            livesText.text = lives.ToString();
        }

        else if (lives <= 0){
            gameOver = true;
        }

    }


    public void candyTolife()
    {
        lives++;
        print("lifegained");
        livesText.text = lives.ToString();
    }

    public void GameOver()
    {
        CandySpawner.instance.StopCandies();   
        GameObject.Find("Player").GetComponent<PlayerController>().canRun = false;
    }

    public void scoreIncrement()
    {
        score++;
        scoreText.text = score.ToString();
        scored = true;
    }
}
