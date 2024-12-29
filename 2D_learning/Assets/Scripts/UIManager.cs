using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //UI manager:
    public static UIManager instance { 
        get; 
        private set; 
    }

    private void Start()
    {
        instance = this; 
    }

    public Image healthBar;
    public void UpdateHealthBar(int curAmount, int maxAmount) { 
        healthBar.fillAmount = (float)curAmount/(float)maxAmount;

    }
}
