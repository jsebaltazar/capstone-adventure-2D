using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : Interactable
{

    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public string dialog;


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
        if(other.CompareTag("Player") && !other.isTrigger  )
        {
            contextSignal.Raise();
            Debug.Log("Player in range");
            playerInRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            contextSignal.Raise();
            Debug.Log("Player left range");
            playerInRange = false;
            dialogBox.SetActive(false);
        }

    }
}
