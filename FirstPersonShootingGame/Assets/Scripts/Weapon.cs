using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject[] weapons;
    private int currentweapon = 0;
    

    // Update is called once per frame
    void Update()
    {
        weaponchange();
    }
    void weaponchange()
    {
        float scrollview = Input.GetAxis("Mouse ScrollWheel");
        if(scrollview > 0f)
        {
            currentweapon++;
            if(currentweapon >= weapons.Length)
            {
                currentweapon = 0;  
            }
            SwitchWeapon(currentweapon);
        }
        
        else if (scrollview < 0f)
        {
            currentweapon--;
            if (currentweapon < 0f)
            {
                currentweapon = weapons.Length - 1;
            }
            SwitchWeapon(currentweapon);

        }
    }

    void SwitchWeapon(int index)
    {
        foreach(GameObject weapons in weapons) 
        {
            weapons.SetActive(false);
        }
        weapons[index].SetActive(true);
    }
}
