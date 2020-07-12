using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSliderHealthBar : MonoBehaviour
{
    public Slider slider;

    public void ChangeHealthBar(float currentHealth)
    {
        slider.value = currentHealth;
    }
}
