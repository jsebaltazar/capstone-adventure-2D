using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JoystickController : MonoBehaviour
{
    public Button left,right,up,down;
//
    private Vector3 change;

    // Update is called once per frame

    void checkJoystickUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLeft();
    
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
