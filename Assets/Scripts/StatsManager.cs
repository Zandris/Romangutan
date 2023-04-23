using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public PlayerController playerController;
    public Text HP;
    public Text Shield;
    public Text Points;

    private float hp;
    private float maxHP;
    private string HPS;
    private float shield;
    private float maxShield;
    private string ShieldS;
    private float points;
    private string pointsS;

    private void Start() 
    {
        hp = playerController.currentHealth;
        maxHP = playerController.maxHealth;
        shield = playerController.currentShield;
        maxShield = playerController.maxShield;
        points = playerController.upgradePoints;
    }

    public void Update() 
    {
        hp = playerController.currentHealth / 100;
        maxHP = playerController.maxHealth / 100;
        shield = playerController.currentShield / 100;
        maxShield = playerController.maxShield / 100;
        points = playerController.upgradePoints;

        HPS = "Életerő: " + hp.ToString() + "/" + maxHP.ToString();
        HP.text = HPS;
        ShieldS = "Pajzs: " + (Mathf.Round(shield)).ToString() + "/" + maxShield;
        Shield.text = ShieldS;
        pointsS = "Pontok: " + points;
        Points.text = pointsS;
    }
}
