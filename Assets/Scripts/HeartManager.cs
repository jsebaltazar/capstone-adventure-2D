using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] heart;
    public Sprite fullHeart;
    public Sprite emptyHearts;
    public Sprite halfFullHeart;
    public FloatValue heartContainers;

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
     }

    public void InitHearts()
    {
        Debug.Log(heart.Length);
        for (int i = 0; i < heartContainers.initialValue; i++)
        {

            heart[i].sprite= fullHeart;
            heart[i].gameObject.SetActive(true);
        }
    }
}
