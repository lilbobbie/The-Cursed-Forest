using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Singleton code
    public static PlayerManager Instance;
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

    //Player Manager code
    private int score = 0;

    public void AddScorePoints(int points)
    {
        score = score + points;
    }

    public int GetScore()
    {
        return score;
    }
}
