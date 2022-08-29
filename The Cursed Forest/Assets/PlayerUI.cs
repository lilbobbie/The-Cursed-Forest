using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Texture2D fullHeart;
    public Texture2D emptyHeart;
    public TextMeshProUGUI score;
    public TextMeshProUGUI money;
    int _score;
    int _money;

    private void Awake()
    {
    }

    private void Update()
    {
        _score = PlayerManager.Instance.GetScore();
        score.text = "Score: " + _score.ToString();

        _money = PlayerManager.Instance.GetMoney();
        money.text = _money.ToString() + "$";
    }
}
