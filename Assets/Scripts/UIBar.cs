using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    [SerializeField]
    private Image _staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        _staminaBar.fillAmount = 1; 
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    public void Bar(float value, float inMin, float inMax, float outMin, float outMax)
    {
        _staminaBar.fillAmount = Map(value, inMin, inMax, outMin, outMax);
    }

}
