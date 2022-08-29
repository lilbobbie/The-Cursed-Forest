using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryUI : MonoBehaviour
{
    public TextMeshProUGUI score;
    public AudioClip victorySound;

    private void OnBecameVisible()
    {
        GameObject.Find("Player").GetComponent<AudioSource>().PlayOneShot(victorySound);
        score.text = "Your Score: " + PlayerManager.Instance.GetScore().ToString();
    }

    public void RestartGame()
    {
        GameManager.Instance.RestartGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
