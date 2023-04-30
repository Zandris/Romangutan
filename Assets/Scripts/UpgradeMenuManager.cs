using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuManager : MonoBehaviour
{
    public HealthBar healthBar;
    public ShieldBar shieldBar;
    public PlayerController playerController;
    public VariableManager variableManager;

    public Text ItemInformation;
    public Text Price;

    //[HideInInspector] public bool HealthUpgrade;
    //[HideInInspector] public bool ShieldUpgrade;
    //többi szar ide

    private void Start() 
    {
        variableManager = GameObject.Find("VariableManager").GetComponent<VariableManager>();
    }

    public void ButtonManager () 
        {
            if (gameObject.tag == "HealthUpgrade") {
                //playerController.maxHealth += 1000;
                //healthBar.SetMaxHealth(playerController.maxHealth);
                variableManager.HealthUpgrade = true;
                //Debug.Log(HealthUpgrade);
                //minden más false
                variableManager.ShieldUpgrade = false;

                ItemInformation.text = "Leírás: Az életerő növelése tízzel";
                Price.text = "Ár: 1";
            }

            if (gameObject.tag == "ShieldUpgrade") {
                variableManager.ShieldUpgrade = true;

                ItemInformation.text = "Leírás: A pajzs növelése tízzel";
                Price.text = "Ár: 2";

                variableManager.HealthUpgrade = false;
            }
        }
}
