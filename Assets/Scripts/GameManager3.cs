﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{
    public float restartDelay;
    public GameObject tryAgainUI;
    public GameObject startMenuUI;
    public GameObject scoreUI;

    public GameObject player;
    public GameObject levelManager;

    public static bool gameHasEnded = false;

    public static bool gameHasStarted = false;
    public static float gameStartedTime;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("BackgroundMusic");
    }

    private void Update()
    {
        if (gameHasStarted)
        {
            scoreUI.SetActive(true);
            startMenuUI.SetActive(false);
        }
        else
        {
            scoreUI.SetActive(false);
            startMenuUI.SetActive(true);
        }
    }

    public void LoadGameMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameHasStarted = false;
        gameHasEnded = false;
        startMenuUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameHasStarted = false;
        gameHasEnded = false;
        StartGame();
    }

    public void StartGame()
    {
        gameStartedTime = Time.time;
        gameHasStarted = true;

        FindObjectOfType<AudioManager>().Play("Wind");
        startMenuUI.SetActive(false);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            FindObjectOfType<AudioManager>().Stop("BackgroundMusic");
            FindObjectOfType<AudioManager>().Stop("Wind");

            FindObjectOfType<AudioManager>().Play("PlayerDeath");

            scoreUI.GetComponent<Animator>().SetTrigger("IsEnded");
            gameHasEnded = true;

            Debug.Log("GAME OVER!");
            TryAgain();
            //Invoke("Restart", restartDelay);
        }
    }

    void TryAgain()
    {
        tryAgainUI.SetActive(true);
    }
}