using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private HealthManager healthman;
    public float waitToHurt = 1.5f;//How long it takes for enemy to strike again
    public bool isTouching;
    [SerializeField] private int EnemyDamage = 10;

    void Start()
    {
        healthman = FindObjectOfType<HealthManager>();
    }

    void Update()
    {
        if(isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if(waitToHurt <= 0)
            {
                healthman.TakeDamage(EnemyDamage);//Amount of damage enemy gives (EnemyDamage)
                waitToHurt = 1.5f;//How long it takes for enemy to strike again
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {

            other.gameObject.GetComponent<HealthManager>().TakeDamage(EnemyDamage);//Amount of damage (EnemyDamage)
            //other.gameObject.SetActive(false);
            //other.gameObject.GetComponent<HealthManager>(HurtPlayer(10));
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    private void OnCollisionStay2D(Collision2D other)//When Enemy begins thouching player
    {
        if(other.collider.tag == "Player")
        {
            isTouching = true;
        }
        
    }

    void OnCollisionExit2D(Collision2D other)//When enemy "stops" thouching player
    {
        if(other.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2;
        }
    }

}
