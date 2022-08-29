using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 1;
    public int scorePoints = 20;
    public int money = 5;

    public GameObject deathEffect;


    private void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        PlayerManager.Instance.AddScorePoints(scorePoints);
        PlayerManager.Instance.AddMoney(money);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            PlayerManager.Instance.TryDamage(damage);
        }
    }
}
