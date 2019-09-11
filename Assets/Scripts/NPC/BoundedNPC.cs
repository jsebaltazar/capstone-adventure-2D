using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Interactable
{
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidBody;
    private Animator anim;
    public Collider2D B;
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidBody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerInRange)
          Move();
    }
    void Move()
    {

        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (B.bounds.Contains(temp))
        {
            myRigidBody.MovePosition(temp);

        }
        else
        {
            Debug.Log((B.bounds.Contains(temp)));
            ChangeDirection();
        }
    }
    void ChangeDirection()
    {

        int direction = Random.Range(0, 4);
        switch(direction)
        {
            case 0:
                directionVector = Vector3.right;
                break;
            case 1:
                directionVector = Vector3.up;
                break;
            case 2:
                directionVector = Vector3.left;
                break;
            case 3:
                directionVector = Vector3.down;
                break;
            default: break;
            
        }
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        anim.SetFloat("moveX", directionVector.x);
        anim.SetFloat("moveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int count = 0;
        while(temp == directionVector && count < 99)
        {
            count++;
            ChangeDirection();
        }
    }
}
