using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    public Rigidbody2D myRigidBody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        myRigidBody = GetComponent<Rigidbody2D>();
        anim.SetBool("wakeup", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    public virtual void CheckDistance()
    {
        if (Vector3.Distance(target.position,
                              transform.position) <= chaseRadius
                                 && Vector3.Distance(target.position,
                                        transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk 
                && currentState != EnemyState.stagger)
            {

                Vector3 temp = Vector3.MoveTowards(transform.position,
                                                      target.position,
                                                      moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);

              
                ChangedState(EnemyState.walk); 
                anim.SetBool("wakeUp", true);
            }
        }
        else if(Vector3.Distance(target.position,
                              transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }

    }

    private void ChangedState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }
    public void changeAnim(Vector2 direction)
    {
        Debug.Log(direction);
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            Debug.Log("x is >");
            if(direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            Debug.Log("y is >");
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }
}
