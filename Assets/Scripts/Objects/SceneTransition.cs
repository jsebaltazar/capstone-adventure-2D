using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerLocation;
    public GameObject fadePanel;

    private void Awake()
    {
        if(fadePanel != null)
        {
            GameObject panel = Instantiate(fadePanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            Debug.Log("Loading SampleScene");
            playerLocation.initialValue = playerPosition;
            SceneManager.LoadScene(sceneToLoad);

        }
       
    }
}
 