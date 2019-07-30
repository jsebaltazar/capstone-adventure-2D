using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public Vector2 cameraChange; //how much camera moves
    public Vector3 playerChange; //how much player moves
    private CameraMovement cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;

        }
    }
}
