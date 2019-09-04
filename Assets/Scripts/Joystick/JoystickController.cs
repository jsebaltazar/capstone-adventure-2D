using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JoystickController : MonoBehaviour
{
    public Button left,right,up,down;

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
        }
  
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            right.onClick.Invoke();
            Debug.Log("Right!");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            up.onClick.Invoke();
            Debug.Log("Up!");
        }
          
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            down.onClick.Invoke();
            Debug.Log("Down!");
        }
     }

    void moveLeft()
    {
        Input.GetButton("Horizontal");
    }
    void moveRight()
    {

    }
    void moveUp()
    {

    }
    void moveDown()
    {

    }
}
