using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image healthBar;
    public float health;
    public float startHealth;

    private void Awake()
    {
        startHealth = GetComponent<Enemy>().health;
    }

    private void Update()
    {

        health = GetComponent<Enemy>().health;
        healthBar.fillAmount = health / startHealth;
    }
}