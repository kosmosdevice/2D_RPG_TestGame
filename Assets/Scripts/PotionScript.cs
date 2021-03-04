using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour// Det här scriptet är bara tillfälligt innan vi fixar inventrory
{
    [SerializeField]
    public HealthManager healthManager;

    [SerializeField]
    int HealthAmount;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (healthManager.currentHealth < 100 && healthManager.currentHealth != (100 + HealthAmount))//För health
        {
            healthManager.currentHealth += HealthAmount;
            healthManager.AddHealth();
            Destroy(this.gameObject);
        }

        if (collider.gameObject.tag == "Player") // för mana
        {
            Debug.Log("Mana potion working");
        }
    }
}
