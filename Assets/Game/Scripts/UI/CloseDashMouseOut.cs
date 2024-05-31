using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDashMouseOut : MonoBehaviour
{
    public GameObject dash;
    public GameEvent GameEvent
        ;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out hit) || hit.transform.gameObject != gameObject)
            {
                GameEvent.Play();
                dash.SetActive(false);
            }
        }
    }
}
