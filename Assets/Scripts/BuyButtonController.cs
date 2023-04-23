using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonController : MonoBehaviour
{
    public UpgradeMenuManager upgradeMenuManager;
    public PlayerController playerController;
    public HealthBar healthBar;

    private bool HealthUpgrade;
    private int upgradePoints;

    private void Update() 
    {
        HealthUpgrade = upgradeMenuManager.HealthUpgrade;
        upgradePoints = playerController.upgradePoints;
    }

    public void BuyButton () 
    {

        //Debug.Log("buybutton");
        //Debug.Log(HealthUpgrade + " " + upgradePoints);

        if (HealthUpgrade == true && upgradePoints > 0) {
            playerController.maxHealth += 1000;
            healthBar.SetMaxHealth(playerController.maxHealth);
            playerController.upgradePoints -= 1;
            Time.timeScale = 0f;
            //Debug.Log("healthupgrade");
        }
    }
}
