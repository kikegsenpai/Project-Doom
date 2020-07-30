using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagerPlayer : MonoBehaviour
{
    public SoundManagerScript soundFX;
    public Slider healthBar;
    public float currentHealth = 100f;
    public float maxHealth = 100f;
    public float lerpSpeed=20f;
    public float healing = 30f;
    public Color max,min,currColor;
    public Animator animacion;
    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        currColor = Color.Lerp(min, max, currentHealth/maxHealth);
        currColor.a = 1f;
        healthBar.fillRect.gameObject.GetComponent<Image>().color = currColor;
        healthBar.value = Mathf.Lerp(healthBar.value, currentHealth, Time.deltaTime * lerpSpeed);
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }


        if (this.animacion.GetCurrentAnimatorStateInfo(0).IsName("Drink"))
        {
            hasStarted = true;
        }
        if (!this.animacion.GetCurrentAnimatorStateInfo(0).IsName("Drink") && hasStarted)
        {
            if ((currentHealth + healing) >= maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth = currentHealth + healing;
            }
            soundFX.playSound("burp");
            hasStarted = false;
        }
    }

    public void recibeImpacto(float damage)
    {
        currentHealth -= damage;
    }
    public void curaVida(float heal)
    {
        animacion.SetTrigger("Beber");
        healing = heal;
    }
}
