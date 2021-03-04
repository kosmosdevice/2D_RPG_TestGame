using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public Transform target { get; set;}
    private NPC currentTarget;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          ClickSelect();
          //gör en annan för hover select med HoverSelect(); if(... && !EventSystem.current.IsPointerOverGameObject())*/
    }

    private void ClickSelect()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
            

            if (hit.collider != null)
            {
                Debug.Log(hit.transform.name);
                target = hit.transform;
                if(currentTarget != null)
                {
                    currentTarget.DeSelect();
                }
            currentTarget = hit.collider.GetComponent<NPC>();
            target = currentTarget.Select();
            } 
            else
            {
                if (currentTarget != null)
                {
                    currentTarget.DeSelect();
                }
                currentTarget = null;
                target = null;
            }     
        }       
    }

    /*private void ClickTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, 8);

            if(hit.collider != null)
            {
                player.MyTarget = hit.transform;
            }
        }
    }*/
}
