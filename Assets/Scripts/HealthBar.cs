using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void Start() 
    {
        slider = GetComponent<Slider>();
        slider.value = 10;    
    }

    public void SetMaxHealth(int health) 
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health) 
    {
        slider.value = health;
    }

    public void Update() 
    {
        //Debug.Log("healthBar: slider.value: " + slider.value + " slider.maxvalue:" + slider.maxValue);
    }
}
