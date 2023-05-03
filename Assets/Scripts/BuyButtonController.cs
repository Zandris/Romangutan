using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonController : MonoBehaviour
{
    public UpgradeMenuManager upgradeMenuManager;
    public PlayerController playerController;
    public HealthBar healthBar;
    public ShieldBar shieldBar;
    public VariableManager variableManager;
    public PlayerBulletController playerBulletController;

    private bool ShieldUpgrade;
    private bool HealthUpgrade;
    private int upgradePoints;

    private void Start() 
    {
        variableManager = GameObject.Find("VariableManager").GetComponent<VariableManager>();
    }

    public void BuyButton () 
    {
        upgradePoints = playerController.upgradePoints;

        //Debug.Log("buybutton");
        //Debug.Log("HealthUpgrade: " + variableManager.HealthUpgrade + " " + "ShieldUpgrade: " + variableManager.ShieldUpgrade);

        if (variableManager.HealthUpgrade == true && upgradePoints > 0) {
            playerController.maxHealth += 1000;
            healthBar.SetMaxHealth(playerController.maxHealth);
            playerController.upgradePoints -= 1;
            Time.timeScale = 0f;
            //Debug.Log("BuyButton(): HealthUpgrade");
        } else if (variableManager.ShieldUpgrade == true && upgradePoints >= 2) {
            playerController.maxShield += 1000;
            shieldBar.SetMaxShield(playerController.maxShield);
            playerController.upgradePoints -= 2;
            Time.timeScale = 0f;
            //Debug.Log("BuyButton(): ShieldUpgrade");
        } else if (variableManager.FirePowerUpgrade == true && upgradePoints >= 3) {
            playerBulletController.absDelay -= 2.5f;
            playerController.upgradePoints -= 3;
            Time.timeScale = 0f;
            //Debug.Log("BuyButton(): FirePowerUpgrade");
        }
    }
}
