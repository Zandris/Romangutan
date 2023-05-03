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
                variableManager.HealthUpgrade = true;

                //minden más false

                variableManager.ShieldUpgrade = false;
                variableManager.FirePowerUpgrade = false;

                ItemInformation.text = "Leírás: Az életerő növelése 10-el";
                Price.text = "Ár: 1";
            }

            if (gameObject.tag == "ShieldUpgrade") {
                variableManager.ShieldUpgrade = true;

                ItemInformation.text = "Leírás: A pajzs növelése 10-el";
                Price.text = "Ár: 2";

                variableManager.HealthUpgrade = false;
                variableManager.FirePowerUpgrade = false;
            }

            if (gameObject.tag == "FirePowerUpgrade") {
                variableManager.FirePowerUpgrade = true;

                ItemInformation.text = "Leírás: A tűzerő növelése 2.5-el";
                Price.text = "Ár: 3";

                variableManager.ShieldUpgrade = false;
                variableManager.HealthUpgrade = false;
                //max 3at lehessen vagy 4 et
            }
        }
}
