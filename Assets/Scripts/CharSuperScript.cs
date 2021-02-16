using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharSuperScript : MonoBehaviour 
{ // Fungerar som en parent Script. (Unity Abstract script)

    [SerializeField] private float speed;
    protected Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }
    
    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
    
