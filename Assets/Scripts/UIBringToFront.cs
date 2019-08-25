using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIBringToFront : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
  public void OnPointerDown(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
    }
}
