using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{

    public Signal contextSignal;

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;

    // Update is called once per frame
    void Update()
    {

        if(playerInRange == true && Input.GetKeyDown(KeyCode.C))
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.transform.SetAsLastSibling();
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            contextSignal.Raise();
            Debug.Log("Player in range");
            playerInRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            contextSignal.Raise();
            Debug.Log("Player left range");
            playerInRange = false;
            dialogBox.SetActive(false);
        }

    }
}
