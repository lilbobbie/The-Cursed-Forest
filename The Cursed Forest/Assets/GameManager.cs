using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    GameStart,
    Shop,
    Pause,
    Play,
    GameOver,
    QuitGame,
    Victory
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
    public GameObject victoryUI;
    public GameObject shopUI;

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
                OpenShop();
                break;
            case GameState.Pause:
                pauseUI.SetActive(true);
                Time.timeScale = 0;
                break;
            case GameState.Play:
                Time.timeScale = 1;
                shopUI.SetActive(false);
                pauseUI.SetActive(false);
                startUI.SetActive(false);
                gameOverUI.SetActive(false);
                playerUI.SetActive(true);
                break;
            case GameState.GameOver:
                Time.timeScale = 0;
                playerUI.SetActive(false);
                pauseUI.SetActive(false);
                gameOverUI.SetActive(true);
                break;
            case GameState.QuitGame:
                Application.Quit();
                break;
            case GameState.Victory:
                Victory();
                break;
            default:
                break;
        }
    }

    public GameState GetGameState()
    {
        return currentGameState;
    }

    private void Victory()
    {
        victoryUI.SetActive(true);
        Time.timeScale = 0;
    }

    private void OpenShop()
    {
        shopUI.SetActive(true);
        GameObject.Find("PlayerManager").GetComponent<Health>().health = GameObject.Find("PlayerManager").GetComponent<Health>().numOfHearts;
    }

    private void StartGame()
    {
        Time.timeScale = 0;
        Debug.Log("StartGame function called");
        if(startUI == null)
        {
            startUI = GameObject.Find("Start UI");
        }
        startUI.SetActive(true);
        Debug.Log("StartGame function finished");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
