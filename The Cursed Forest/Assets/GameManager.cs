using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    GameStart,
    Shop,
    Pause,
    Play,
    GameOver,
    QuitGame
}

public class GameManager : MonoBehaviour
{
    //Singleton code
    public static GameManager Instance;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    //GameManager code
    public GameObject startUI;
    public GameObject pauseUI;
    public GameObject gameOverUI;
    public GameObject playerUI;

    private GameState currentGameState;

    private void Start()
    {
        UpdateGameState(GameState.GameStart);
    }

    public void UpdateGameState(GameState state)
    {
        currentGameState = state;
        switch (state)
        {
            case GameState.GameStart:
                Debug.Log("GameState Updated to GameStart");
                StartGame();
                break;
            case GameState.Shop:
                break;
            case GameState.Pause:
                pauseUI.SetActive(true);
                Time.timeScale = 0;
                break;
            case GameState.Play:
                Time.timeScale = 1;
                pauseUI.SetActive(false);
                startUI.SetActive(false);
                gameOverUI.SetActive(false);
                playerUI.SetActive(true);
                break;
            case GameState.GameOver:
                break;
            case GameState.QuitGame:
                Application.Quit();
                break;
            default:
                break;
        }
    }

    public GameState GetGameState()
    {
        return currentGameState;
    }

    private void StartGame()
    {
        Debug.Log("StartGame function called");
        Time.timeScale = 0;
        if(startUI == null)
        {
            startUI = GameObject.Find("Start UI");
        }
        startUI.SetActive(true);
        Debug.Log("StartGame function finished");
    }
}
