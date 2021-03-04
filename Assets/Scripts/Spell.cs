using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : GameManager
{
    private Rigidbody2D myRigidBody2D;

    [SerializeField]
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        //target = GameObject.Find("WarriorSkeleton").transform;//ta bort senare är inte bra att ha skapa en void


    }

    private void FixedUpdate()
    {

        if (target != null)
        {
            Vector2 direction = target.position - transform.position;

            myRigidBody2D.velocity = direction.normalized * speed;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}

