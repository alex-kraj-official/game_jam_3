using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class GateController : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float armor;
    public float lvl;
    public float upgradeCost;
    public float repairCost;

    public GameManager manager;

    public TextMeshProUGUI CurrentGateHealth;

    private void Start()
    {
        CurrentGateHealth.SetText(currentHealth.ToString());
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            manager.loseGame();
            Destroy(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            takeDamage(10);
        }
    }
    public void takeDamage(float amount)
    {
        currentHealth = currentHealth + armor - amount;
        CurrentGateHealth.SetText(currentHealth.ToString());
    }
    public void repair()
    {
        currentHealth = currentHealth + 5 * lvl;
        CurrentGateHealth.SetText(currentHealth.ToString());
    }
    public void upgrade()
    {
        maxHealth = maxHealth + 50;
        currentHealth = maxHealth;
        armor = armor + 3;
        lvl++;
        upgradeCost = upgradeCost + 50;
        CurrentGateHealth.SetText(currentHealth.ToString());
    }
}
