using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaManager : MonoBehaviour
{ 
   public int maxMana = 100;
   public int currentMana;
   
   public ManaBar manaBar;
   
   void Start()
   {
        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
   }
   
   void Update()
   {
        if (currentMana >= 10)
        {
            if (Input.GetKeyDown("space"))
            {
                UseMana(10);
            }
        }
   }
   
   void UseMana(int mana)
   {
        currentMana -= mana;
        manaBar.SetMana(currentMana);
   }
}
