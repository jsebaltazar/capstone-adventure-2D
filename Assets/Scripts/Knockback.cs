using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if(enemy != null)
            {
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                Debug.Log("StartCoroutine");
                StartCoroutine(KnockCo(enemy));

            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if(enemy != null) // check if dead
        {

            Debug.Log("enemy");
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;

        }
    }



}
