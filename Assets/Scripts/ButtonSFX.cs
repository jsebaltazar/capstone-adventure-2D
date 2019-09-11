using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{

    public AudioSource sFX;
    public AudioClip hoverFx;
    public AudioClip clickFx;

    public void HoverSound()
    {
        sFX.PlayOneShot(hoverFx);
    }

    public void ClickSound()
    {
        sFX.PlayOneShot(clickFx);
    }
        
}
