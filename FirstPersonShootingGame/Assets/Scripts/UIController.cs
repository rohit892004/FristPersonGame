using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public Image damageEffect;
    public float damageAlpha = 0.3f;
    public float damageFadeSpeed;
    public static UIController instance;
    public Text ammmoText;
    
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        recoverintoNormal();
    }
    public void DamageEfect()
    {
        damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.b, damageEffect.color.b,damageAlpha);
    }

    void recoverintoNormal()
    {
        if (damageEffect.color.a != 0)
        {
            damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b, Mathf.MoveTowards(damageEffect.color.a, 0f, damageFadeSpeed * Time.deltaTime));
        }
    }
}
