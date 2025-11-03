using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{
    public Slider slider;
    
    public void Maxhealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void Sethealth(float health)
    {
        slider.value = health;
    }
}
