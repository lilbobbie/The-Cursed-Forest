using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Button pressed, StartGame function called");
        GameManager.Instance.UpdateGameState(GameState.Play);
    }
    public void PauseGame()
    {
        GameManager.Instance.UpdateGameState(GameState.Pause);
    }
    public void ResumeGame()
    {
        GameManager.Instance.UpdateGameState(GameState.Play);
    }
    public void OpenShop()
    {
        GameManager.Instance.UpdateGameState(GameState.Shop);
    }
    public void ExitGame()
    {
        GameManager.Instance.UpdateGameState(GameState.QuitGame);
    }
}
