using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{ 
    private Rigidbody2D myRB;
    private Animator myAnim;

    [SerializeField]
    protected ManaManager manaManager;

    [SerializeField]
    private GameObject[] spellPrefab;

    private bool isAttacking;
    private bool AttackActive = false;

    private Coroutine attackRoutine;

    public Transform MyTarget
    {
        get;
        set;
    }

    // Start is called before the first frame update
    void Start()
    {


        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }


    // Update is called once per frame
    protected override void Update()
    {
        myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime;

        myAnim.SetFloat("moveX", myRB.velocity.x);
        myAnim.SetFloat("moveY", myRB.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        //if (isAttacking)
        //{
        //myRB.velocity = Vector2.zero;
        //}

        if (Input.GetMouseButtonDown(1))//Meele attack (left mouse button)
        {
            if (!isAttacking) //&& myRB.velocity == Vector2.zero)
            {
                attackRoutine = StartCoroutine(MeeleAttack());
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))//Spell attack (right mouse button)
        {
            if (!isAttacking && myRB.velocity == Vector2.zero && manaManager.currentMana >= 50f)
            {
                attackRoutine = StartCoroutine(SpellAttack());
            }                       
        }
        
        if (myRB.velocity != Vector2.zero & AttackActive == true)
        {
            StopAttack();
            //StopAttackMeele(); Borttagen för quick meele
            AttackActive = false;
        }
        base.Update();

    }

    private IEnumerator MeeleAttack()
    {
        //AttackActive = true;
        isAttacking = true;
        myAnim.SetBool("isAttacking", isAttacking);
        yield return new WaitForSeconds(.1f);
        //manaManager.UseMana(50f); Byt till stanima senare
        Debug.Log("Meele Attack Done");
        StopAttackMeele();
        
    }

    //player attack with obj
    private IEnumerator SpellAttack()
    {
        AttackActive = true;
        isAttacking = true;
        myAnim.SetBool("isAttacking", isAttacking);
        yield return new WaitForSeconds(3);
        CastSpell();
        manaManager.UseMana(50f);
        //Debug.Log("Attack Done");
        StopAttack();
              
    }

    void StopAttackMeele()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            isAttacking = false;
            myAnim.SetBool("isAttacking", false);
            //Debug.Log("Meele Attack Off");
            AttackActive = false;
        }
    }

    void StopAttack()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            isAttacking = false;
            myAnim.SetBool("isAttacking", false);
            //Debug.Log("Attack Off");
            AttackActive = false;
        }
    }

    public void CastSpell()
    {
        Instantiate(spellPrefab[0],transform.position, Quaternion.identity);
    }

}
//Vi borde implementera denna tutorialen https://www.youtube.com/watch?v=1MgnZ3SK_h8&list=PLX-uZVK_0K_6JEecbu3Y-nVnANJznCzix&index=9&t=176s&ab_channel=inScopeStudios