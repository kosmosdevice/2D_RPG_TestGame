using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text hpText;
    [SerializeField] HealthManager healthmana;

    void Update()
    {
        hpText.text = "HP: " + healthmana.currentHealth + "/" + healthmana.maxHealth;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);

    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}


/* För att sätta in i ett player script!
 * 
 * public int maxHealth = 100;
 * public int currentHealth;
 * 
 * public HealthBar healthBar;
 * 
 * void Start()
 * {
 *      currentHealth = maxHealth;
 *      healthBar.SetMaxHealth(maxHealth);
 * }
 * 
 * void Update()
 * {
 *      if(Vilkoret hur man ska ta skada)
 *      {
 *          TakeDamage(10);
 *      }
 * }
 * 
 * void TakeDamage(int damage)
 * {
 *      currentHealth -= damage;
 *      healthBar.SetHealth(currentHealth);
 * }
 */