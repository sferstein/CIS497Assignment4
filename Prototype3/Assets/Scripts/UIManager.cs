using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Sam Ferstein
 * Assignment 4
 * This manages the UI.
 */

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public PlayerController playerController;
    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        if(scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }
        if(playerController == null)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerController.gameOver)
        {
            scoreText.text = "Score: " + score;
        }
        if(playerController.gameOver && !won)
        {
            scoreText.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }
        if(score >= 10)
        {
            playerController.gameOver = true;
            won = true;

            //playerController.StopRunning();

            scoreText.text = "You Win!" + "\n" + "Press R to Try Again!";
        }
        if(playerController.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
