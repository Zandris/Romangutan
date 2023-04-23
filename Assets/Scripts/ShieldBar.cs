using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider slider;
 
    public bool shieldState;

    public void Start() 
    {
        slider = GetComponent<Slider>();
        //slider.value = 50;    
    }

    public void SetMaxShield(float shield) 
    {
        slider.maxValue =  shield;
        slider.value = shield;
    }

    public void SetShield(float shield) 
    {
        slider.value = shield;
    }
}
