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
    public float invulnerabilityTime = 0.5f;
    private bool canBeDamaged = true;
    private int money = 100;

    public void AddScorePoints(int points)
    {
        score = score + points;
    }

    public void AddMoney(int _money)
    {
        money = money + _money;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetMoney()
    {
        return money;
    }

    public void TryDamage(int damage)
    {
        if (canBeDamaged)
        {
            DamagePlayer(damage);
        }
    }

    private void DamagePlayer(int damage)
    {
        canBeDamaged = false;
        GetComponent<Health>().health -= damage;
        if (GetComponent<Health>().health == 0)
        {
            GameManager.Instance.UpdateGameState(GameState.GameOver);
        }
        Invoke("ResetDamage", invulnerabilityTime);
    }
    private void ResetDamage()
    {
        canBeDamaged = true;
    }

    public void UpgradeHealth()
    {
        if(GetComponent<Health>().numOfHearts < 8)
        {
            GetComponent<Health>().numOfHearts++;
            GetComponent<Health>().health = GetComponent<Health>().numOfHearts;
            money = money - 20;
        }
    }

    public void UpgradeAttack()
    {
        if(GameObject.Find("Player").GetComponent<PlayerCombat>().timeBetweenShots > 0.1f)
        {
            GameObject.Find("Player").GetComponent<PlayerCombat>().timeBetweenShots -= 0.5f;
            money = money - 40;
        }
    }
}
