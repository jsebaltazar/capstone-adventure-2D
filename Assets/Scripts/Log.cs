using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    private Rigidbody2D myRigidBody;
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
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
                myRigidBody.MovePosition(temp);
                ChangedState(EnemyState.walk);
            }
        }

    }

    private void ChangedState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
