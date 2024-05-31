using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenURL : MonoBehaviour, IPointerClickHandler
{
    public string LincURL;
    public void OnPointerClick(PointerEventData eventData)
    {
        GoURL();
    }

    public void GoURL()
    {
        Application.OpenURL(LincURL);
    }
}
