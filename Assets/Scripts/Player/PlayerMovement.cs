using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    public Button left, right, up, down;
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    public Vector3 change;
    private Animator animator;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;
    public VectorValue startingPosition;

    private Vector2 touchOrigin = -Vector2.one;

    public Vector3 Change
    {
        get
        {
            return change;
        }
        set
        {
            change = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
	    animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;

    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_STANDALONE || UNITY_WINDOWS



#else
        if(Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            if( myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;

            }
            else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            {
                Vector2 touchEnd = myTouch.position;
                float x = touchEnd.x - touchOrigin.x;
                float y = touchEnd.y - touchOrigin.y;
                touchOrigin.x = -1;
                if(Mathf.Abs(x) > Mathf.Abs(y))
                    change.x = x > 0 ? 1 : -1;
                else
                    change.y = y > 0 ? 1: -1;
            }
        }
#endif

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

    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {

            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            this.gameObject.SetActive(false);
        }

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




    void checkJoystickUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLeft();
            Debug.Log("Left!");


        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveRight();
            Debug.Log("Right!");

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveUp();
            Debug.Log("Up!");

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDown();
            Debug.Log("Down!");


        }
    }
    public void moveLeft()
    {
         change.y = 0;
        change.x = -1;
        Debug.Log(change);
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack &&
            currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }

    }

    public void moveRight()
    {
        change.y = 0;
        change.x = 1;

    }
    public void moveUp()
    {
        change.y = 1;
        change.x = 0;
    }
    public void moveDown()
    {
        change.y = -1;
        change.x = 0;
    }
}