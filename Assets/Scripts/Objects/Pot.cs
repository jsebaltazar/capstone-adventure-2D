using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator anim;
    private AudioSource breakSound;
    public AudioClip potBreak;
    // Start is called before the first frame update
    void Start()
    {
        breakSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash()
    {

    //    breakSound.PlayOneShot(potBreak);
        anim.SetBool("smash", true);
        StartCoroutine(breakCo());
    }

    IEnumerator breakCo()
    {
        breakSound.Play();
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);
    }
}
