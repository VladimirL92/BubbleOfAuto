using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClosePanelScript : MonoBehaviour, IPointerClickHandler
{
    public GameEvent GameEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameEvent.Play();
    }

}
