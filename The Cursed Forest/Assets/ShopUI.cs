using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopUI : MonoBehaviour
{
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI healthText;

    public TextMeshProUGUI attackPrice;
    public TextMeshProUGUI healthPrice;

    public int attackCounter;
    public int healthCounter;
    public int priceHealth = 20;
    public int priceAttack = 40;

    public int attackLimit = 5;
    public int healthLimit = 5;

    private void Start()
    {
        attackText.text = "Attack " + attackCounter.ToString() + "/" + attackLimit.ToString();
        healthText.text = "Health " + healthCounter.ToString() + "/" + healthLimit.ToString();
    }

    private void Update()
    {
        if(PlayerManager.Instance.GetMoney() >= priceAttack)
        {
            attackPrice.color = Color.green;
        }
        else
        {
            attackPrice.color = Color.red;
        }
        if (PlayerManager.Instance.GetMoney() >= priceHealth)
        {
            healthPrice.color = Color.green;
        }
        else
        {
            healthPrice.color = Color.red;
        }
    }

    public void UpgradeAttack()
    {
        if(attackCounter < attackLimit && PlayerManager.Instance.GetMoney() >= priceAttack)
        {
            PlayerManager.Instance.UpgradeAttack();
            attackCounter++;
            attackText.text = "Attack " + attackCounter.ToString() + "/" + attackLimit.ToString();
        }
    }
    public void UpgradeHealth()
    {
        if (healthCounter < healthLimit && PlayerManager.Instance.GetMoney() >= priceHealth)
        {
            PlayerManager.Instance.UpgradeHealth();
            healthCounter++;
            healthText.text = "Health " + healthCounter.ToString() + "/" + healthLimit.ToString();
        }
    }
}

