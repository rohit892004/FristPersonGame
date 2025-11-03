using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("PlayerHealth")]
    public float CurrneHealth;
    public float maxHealth;
    public float Damageheath;
    public static PlayerHealth instance;
    public Healthbar healthbar;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        CurrneHealth = maxHealth;
        //instance = this;
        healthbar.Maxhealth(CurrneHealth);
    }

 
    public void heathdamge()
    {
        CurrneHealth -= Damageheath;
        UIController.instance.DamageEfect();
        healthbar.Sethealth(CurrneHealth);
        if (CurrneHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
