using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum PlayerState
{
    idle,
    walk,
    attack,
    interact,
    stagger
}
public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
	    animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);


    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        Debug.Log(change);
        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack &&
            currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }

       
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("moving", false);
        animator.SetBool("attacking", true);

        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);

        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
 	if(change != Vector3.zero)
        {

        MoveCharacter();
	    animator.SetFloat("moveX", change.x);
	    animator.SetFloat("moveY", change.y);
        animator.SetBool("moving", true);
        animator.SetBool("attacking", false);
        Debug.Log("Moving, true");


        }
	else
	{
	   animator.SetBool("moving",false);
       animator.SetBool("attacking", false);
 	   Debug.Log("Moving, false");
	}
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
        Debug.Log("MoveChar!");
    } 

    public void Knock(float knockTime)
    {

        StartCoroutine(KnockCo(knockTime));
    }
    private IEnumerator KnockCo(float KnockTime)
    {
        if(myRigidbody != null)
        {
            yield return new WaitForSeconds(KnockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
