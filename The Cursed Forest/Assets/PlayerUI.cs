using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Texture2D fullHeart;
    public Texture2D emptyHeart;
    public TextMeshProUGUI score;
    int iScore;
    int money;

    private void Update()
    {
        iScore = PlayerManager.Instance.GetScore();
        score.text = "Score: " + iScore.ToString();
    }
}
