using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaManager : MonoBehaviour
{ 
   public float maxMana = 100f;
   public float currentMana;
   
   public ManaBar manaBar;
   
   void Start()
   {
        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
   }
   
   void Update()
   {
        if (currentMana >= 10f)
        {
            if (Input.GetKeyDown("space"))
            {
                UseMana(10f);
            }
        }

        if (currentMana < maxMana)
        {
            AddMana();
        }
    }
   
   public void UseMana(float mana)
   {
        currentMana -= mana;
        manaBar.SetMana(currentMana);
   }

    public void Spells(float fireball, float icebolt)
    {
        fireball = 50f;

        icebolt = 25f;
    }

    void AddMana()
    {
        currentMana += 5f * Time.deltaTime;
        manaBar.SetMana(currentMana);

    }
}
