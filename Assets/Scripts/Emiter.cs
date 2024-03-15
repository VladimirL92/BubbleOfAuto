using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emiter : MonoBehaviour
{

    public float MouseLeft = -2f;
    public float MouseRight = 2f;

    public EntityManager Manager;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos = new Vector3(Mathf.Clamp(diference.x, MouseLeft, MouseRight), transform.position.y, transform.position.z);
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Manager.EntityInstantiate(transform.position);
        }
    }


}
